using icons.Core.Dtos.User;
using icons.Data;
using icons.Data.Enums;

namespace icons.Core.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserGetDto>> GetAllUsersAsync();
        Task<UserProfileGetDto> GetUserProfileAsync(string id);
        Task DeleteUserAsync(string id);
        string GetRankImage(EnumUserElixirRank rank);
        Task<EnumUserElixirRank> SetRank(string userId, int elixir);
        Task<bool> PromoteUser(string id);
        Task<bool> DemoteUser(string id);
        Task UpdateRankAsync(ApplicationUser user);
    }
}
