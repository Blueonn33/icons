using icons.Core.Contracts;
using icons.Models;
using icons.Models.Home;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace icons.Controllers
{
    public class HomeController : Controller
    {
        private readonly IIconService _service;

        public HomeController(IIconService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var model = new Top3IconsViewModel()
            {
                Top3Icons = await _service.GetTop3IconsAsync()
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
