using AutoMapper;
using icons.Core.Contracts;
using icons.Core.ViewModels.Leaderboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace icons.Controllers
{
    public class LeaderboardController(ILeaderboardService _leaderboardService, IMapper _mapper) : BaseController
    {
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var usersDto = await _leaderboardService.GetAllUsersAsync();
            var usersViewModel = _mapper.Map<IEnumerable<UserLeaderboardViewModel>>(usersDto.Users);

            AllUsersLeaderboardViewModel allUsers = new AllUsersLeaderboardViewModel()
            {
                Users = usersViewModel
            };

            return View(allUsers);
        }
    }
}
