using icons.Core.Contracts;
using icons.Models.Icons;
using Microsoft.AspNetCore.Mvc;

namespace icons.Controllers
{
    public class IconsController : Controller
    {
        private readonly IIconService _service;

        public IconsController(IIconService service)
        {
            _service = service;
        }

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
    }
}
