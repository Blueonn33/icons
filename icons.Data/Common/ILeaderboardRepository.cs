using icons.Data.Models;

namespace icons.Data.Common
{
    public interface ILeaderboardRepository
    {
        Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();
    }
}
