using icons.Core.Contracts;
using icons.Core.Services;
using icons.Core.ViewModels.Icons;
using icons.Data.Enums;
using icons.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace icons.Controllers
{
    public class IconsController(
        IIconService _service,
        IReviewService _reviewService,
        UserManager<ApplicationUser> _userManager,
        CloudinaryService _cloudinary,
        ILogger<IconsController> _logger) : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index(EnumIconSortOptions sort = EnumIconSortOptions.DateDesc)
        {
            var icons = await _service.GetAllIconsSortedAsync(sort);

            if (icons.GetAllIcons.Any() == false)
            {
                return View("NoIcons");
            }

            return View(icons);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Icon(int id, EnumReviewSortOptions sort = EnumReviewSortOptions.DateDesc)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var icon = await _service.GetIconByIdAsync(id);

            if (icon == null)
            {
                return NotFound();
            }

            icon.Reviews.Reviews = await _reviewService.GetAllReviewsByIconIdSortedAsync(id, sort);
            icon.Reviews.Sort = sort;

            return View(icon);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateIcon(IconInputModel model)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound();
            }

            try
            {
                var imageUrl = await _cloudinary.UploadImageAsync(model.ImageFile, "icons");

                var icon = new IconInputModel()
                {
                    Id = model.Id,
                    ImageUrl = imageUrl,
                    ImageFile = model.ImageFile,
                    Title = model.Title,
                    Description = model.Description,
                    UserId = user.Id
                };

                await _service.AddIconAsync(icon);
                TempData["Success"] = "Успешно създаде икона";
            }
            catch (Exception _)
            {
                _logger.LogCritical("Възникна грешка. Провери logs");
                TempData["Error"] = "Възникна грешка при създаването на иконата";
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteIcon(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            try
            {
                bool isDeleted = await _service.DeleteIconAsync(id);

                if (!isDeleted)
                {
                    return NotFound();
                }

                TempData["Success"] = "Успешно изтри иконата";
            }
            catch (Exception _)
            {
                _logger.LogCritical("Възникна грешка. Провери logs");
                TempData["Error"] = "Възникна грешка при изтриването на иконата";
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var icon = await _service.GetIconByIdAsync(id);
            var user = await _userManager.GetUserAsync(User);

            if (user?.Id != icon?.UserId)
            {
                return NotFound();
            }

            var updateIcon = new IconUpdateInputModel()
            {
                Id = id,
                Title = icon.Title,
                ImageUrl = icon.ImageUrl,
                Description = icon.Description
            };

            return View(updateIcon);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateIcon(int id, IconUpdateInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Update), model);
            }

            var icon = await _service.GetIconByIdAsync(id);
            string imageUrl = icon.ImageUrl;

            try
            {
                if (model.ImageFile != null && model.ImageFile.Length > 0)
                {
                    imageUrl = await _cloudinary.UploadImageAsync(
                        model.ImageFile,
                        "icons");
                }

                var updateIcon = new IconUpdateInputModel
                {
                    Id = model.Id,
                    ImageUrl = imageUrl,
                    ImageFile = model.ImageFile,
                    Title = model.Title,
                    Description = model.Description
                };

                bool isUpdated = await _service.UpdateIconAsync(updateIcon.Id, updateIcon);

                if (!isUpdated)
                {
                    return NotFound();
                }

                TempData["Success"] = "Успешно редактира иконата";
            }
            catch (Exception _)
            {
                _logger.LogCritical("Възникна грешка. Провери logs");
                TempData["Error"] = "Възникна грешка при редактирането на иконата";
            }

            return RedirectToAction("Index");
        }
    }
}
