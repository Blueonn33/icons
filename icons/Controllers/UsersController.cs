using icons.Core.Contracts;
using icons.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace icons.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllUsersAsync();

            var model = new UsersViewModel
            {
                Users = users.Select(u => new UserViewModel()
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    ProfilePictureUrl = u.ProfilePictureUrl,
                    Roles = u.Roles,
                })
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UserProfile(string id)
        {
            var user = await _userService.GetUserProfileAsync(id);

            var model = new UserProfileViewModel()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                ProfilePictureUrl = user.ProfilePictureUrl,
                Icons = user.Icons,
                Reviews = user.Reviews
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await _userService.DeleteUserAsync(id);
            return RedirectToAction("Index");
        }
    }
}
