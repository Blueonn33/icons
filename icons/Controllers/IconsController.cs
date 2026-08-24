using icons.Core.Contracts;
using icons.Core.Dtos.Icon;
using icons.Data;
using icons.Models.Icons;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace icons.Controllers
{
    public class IconsController : Controller
    {
        private readonly IIconService _service;
        private readonly UserManager<ApplicationUser> _userManager;

        public IconsController(IIconService service, UserManager<ApplicationUser> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var icons = new IconsViewModel()
            {
                GetAllIcons = await _service.GetAllIconsAsync()
            };

            if (!icons.GetAllIcons.Any())
            {
                return View("NoIcons");
            }

            return View(icons);
        }

        public async Task<IActionResult> Icon(int id)
        {
            var icon = await _service.GetIconByIdAsync(id);

            return View(icon);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateIcon(IconsCreateViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                throw new InvalidOperationException("User must be logged in to create an icon.");
            }

            var icon = new IconCreateDto()
            {
                ImageUrl = model.ImageUrl,
                Title = model.Title,
                Description = model.Description,
                UserId = user.Id
            };

            await _service.AddIconAsync(icon);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteIcon(int id)
        {
            await _service.DeleteIconAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var icon = await _service.GetIconByIdAsync(id);

            if (icon == null)
            {
                throw new KeyNotFoundException($"Icon with id {id} was not found.");
            }

            var updateIcon = new IconsUpdateViewModel()
            {
                Id = id,
                ImageUrl = icon.ImageUrl,
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
                return View("Index", model);
            }

            var updateIcon = new IconUpdateDto
            {
                Id = model.Id,
                ImageUrl = model.ImageUrl,
                Title = model.Title,
                Description = model.Description
            };

            await _service.UpdateIconAsync(updateIcon.Id, updateIcon);
            return RedirectToAction("Index");
        }
    }
}
