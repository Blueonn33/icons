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
                UserId = user.Id,
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
    }
}
