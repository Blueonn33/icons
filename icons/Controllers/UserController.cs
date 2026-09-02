using Microsoft.AspNetCore.Mvc;

namespace icons.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
