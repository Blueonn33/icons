using AutoMapper;
using icons.Core.Contracts;
using icons.Core.Dtos.Icon;
using icons.Core.Enums;
using icons.Core.Services;
using icons.Data;
using icons.Data.Enums;
using icons.Models.Icons;
using icons.Models.Reviews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace icons.Controllers
{
    [Authorize]
    public class IconsController : Controller
    {
        private readonly IIconService _service;
        private readonly IReviewService _reviewService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly CloudinaryService _cloudinary;
        private readonly IMapper _mapper;
        private readonly ILogger<IconsController> _logger;

        public IconsController(
            IIconService service,
            IReviewService reviewService,
            UserManager<ApplicationUser> userManager,
            CloudinaryService cloudinary,
            IMapper mapper,
            ILogger<IconsController> logger)
        {
            _service = service;
            _reviewService = reviewService;
            _userManager = userManager;
            _cloudinary = cloudinary;
            _mapper = mapper;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index(EnumIconSortOptions sort = EnumIconSortOptions.DateDesc)
        {
            var user = await _userManager.GetUserAsync(User);
            var dtos = await _service.GetAllIconsSortedAsync(sort);

            var icons = new IconsViewModel()
            {
                GetAllIcons = _mapper.Map<IEnumerable<IconViewModel>>(dtos),
                UserId = user?.Id ?? string.Empty,
                Sort = sort
            };

            if (!icons.GetAllIcons.Any())
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

            var reviewDtos = await _reviewService.GetAllReviewsByIconIdSortedAsync(id, sort);

            var model = new IconDescriptionViewModel
            {
                Id = icon.Id,
                ImageUrl = icon.ImageUrl,
                Title = icon.Title,
                Description = icon.Description,
                Username = icon.Username,
                UserProfilePictureUrl = icon.UserProfilePictureUrl,
                UserId = icon.UserId,
                AverageRating = icon.AverageRating,
                Reviews = _mapper.Map<IEnumerable<ReviewViewModel>>(reviewDtos)
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateIcon(IconsCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Create), model);
            }

            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound();
            }

            try
            {
                var imageUrl = await _cloudinary.UploadImageAsync(model.ImageFile, "icons");

                var icon = new IconCreateDto()
                {
                    ImageUrl = imageUrl,
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

            var updateIcon = new IconsUpdateViewModel()
            {
                Id = id,
                Title = icon.Title,
                Description = icon.Description
            };

            return View(updateIcon);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateIcon(int id, IconsUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Create), model);
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

                var updateIcon = new IconUpdateDto
                {
                    Id = model.Id,
                    ImageUrl = imageUrl,
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
