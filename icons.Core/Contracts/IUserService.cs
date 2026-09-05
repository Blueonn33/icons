using icons.Core.Dtos.User;
using icons.Data.Enums;

namespace icons.Core.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserGetDto>> GetAllUsersAsync();
        Task<UserProfileGetDto> GetUserProfileAsync(string id);
        Task DeleteUserAsync(string id);
        string GetRankImage(EnumUserElixirRank rank);
    }
}
