using icons.Core.Dtos.User;

namespace icons.Core.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserGetDto>> GetAllUsersAsync();
        Task DeleteUserAsync(string id);
    }
}
