using icons.Core.Contracts;
using icons.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace icons.Controllers
{
    public class HomeController(IIconService _service) : BaseController
    {
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            if (IsUserAuthenticated)
            {
                return RedirectToAction("Index", "Icons");
            }

            var icons = await _service.GetTop3IconsAsync();
            return View(icons);
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
