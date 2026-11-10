using icons.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace icons.Data.Common
{
    public class LeaderboardRepository(UserManager<ApplicationUser> _userManager) : ILeaderboardRepository
    {
        public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync()
        {
            var users = await _userManager.Users
                .Where(u => u.IsDeleted == false)
                .OrderByDescending(u => u.Elixir)
                .ToListAsync();

            return users;
        }
    }
}
