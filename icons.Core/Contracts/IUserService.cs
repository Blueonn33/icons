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
        string GetRankImageAsync(EnumUserElixirRank rank);
        Task<EnumUserElixirRank> SetRankAsync(string userId, int elixir);
        Task<bool> PromoteUserAsync(string id);
        Task<bool> DemoteUserAsync(string id);
        Task UpdateRankAsync(ApplicationUser user);
    }
}
