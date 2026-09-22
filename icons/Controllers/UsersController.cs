using AutoMapper;
using icons.Core.Contracts;
using icons.Data.Constants;
using icons.Models.Icons;
using icons.Models.Reviews;
using icons.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace icons.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IIconService _iconService;
        private readonly IReviewService _reviewService;
        private readonly IMapper _mapper;

        public UsersController(
            IUserService userService,
            IIconService iconService,
            IReviewService reviewService,
            IMapper mapper)
        {
            _userService = userService;
            _iconService = iconService;
            _reviewService = reviewService;
            _mapper = mapper;
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
                    IsDeleted = u.IsDeleted,
                    Elixir = u.Elixir,
                    Roles = u.Roles,
                })
            };

            var nonAdmins = users.Where(u => !u.Roles.Contains(Roles.Admin));

            if (!nonAdmins.Any())
            {
                return View("NoUsers");
            }

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Forbidden()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> UserProfile(string id)
        {
            var user = await _userService.GetUserProfileAsync(id);
            var iconDtos = await _iconService.GetAllIconsByUserIdAsync(id);
            var reviewsDtos = await _reviewService.GetAllReviewsByUserIdAsync(id);

            var iconModels = _mapper.Map<IEnumerable<IconViewModel>>(iconDtos);
            var reviewModels = _mapper.Map<IEnumerable<ReviewUserProfileViewModel>>(reviewsDtos);

            var model = new UserProfileViewModel()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                ProfilePictureUrl = user.ProfilePictureUrl,
                DateRegistered = user.DateRegistered,
                Elixir = user.Elixir,
                RankImageUrl = _userService.GetRankImageAsync(user.Rank),
                Rank = user.Rank,
                Icons = iconModels,
                Reviews = reviewModels
            };

            return View(model);
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
