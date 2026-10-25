using icons.Core.Contracts;
using icons.Core.ViewModels.Users;
using icons.Data.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace icons.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class UsersController(IUserService _userService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllUsersAsync();
            var nonAdmins = users.Where(u => !u.Roles.Contains(Roles.Admin));

            var model = new UsersAllViewModel()
            {
                Users = users
            };

            if (!nonAdmins.Any())
            {
                return View("NoUsers");
            }

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult NoContentToShow()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> UserProfile(string id)
        {
            var user = await _userService.GetUserProfileAsync(id);

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await _userService.DeleteUserAsync(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> PromoteUser(string id)
        {
            var result = await _userService.PromoteUserAsync(id);

            if (!result)
            {
                return BadRequest("Promotion failed.");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DemoteUser(string id)
        {
            var result = await _userService.DemoteUserAsync(id);

            if (!result)
            {
                return BadRequest("Demotion failed.");
            }

            return RedirectToAction("Index");
        }
    }
}
