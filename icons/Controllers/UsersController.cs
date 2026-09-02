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
                    Username = u.Username,
                    ProfilePictureUrl = u.ProfilePictureUrl,
                    Roles = u.Roles,
                })
            };

            return View(model);
        }
    }
}
