using icons.Core.ViewModels.Users;
using icons.Data.Enums;
using icons.Data.Models;

namespace icons.Core.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> GetAllUsersAsync();
        Task<UserProfileViewModel> GetUserProfileAsync(string id);
        Task DeleteUserAsync(string id);
        string GetRankImage(EnumUserElixirRank rank);
        Task<EnumUserElixirRank> SetRankAsync(string userId, int elixir);
        Task<bool> PromoteUserAsync(string id);
        Task<bool> DemoteUserAsync(string id);
        Task UpdateRankAsync(ApplicationUser user);
    }
}
