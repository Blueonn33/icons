using icons.Core.Contracts;
using icons.Core.Dtos.User;
using icons.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace icons.Core.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task DeleteUserAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                throw new KeyNotFoundException($"User with Id {id} was not found.");
            }

            // Remove User from Database (HardDelete)
            //var result = await _userManager.DeleteAsync(user);

            //if (!result.Succeeded)
            //{
            //    throw new InvalidOperationException("Failed to delete user.");
            //}

            // Remove User from List not from Database (SoftDelete)
            user.IsDeleted = true;
            await _userManager.UpdateAsync(user);
        }

        public async Task<IEnumerable<UserGetDto>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var result = new List<UserGetDto>();

            foreach (var user in users)
            {
                if (user.IsDeleted)
                {
                    continue;
                }

                var roles = await _userManager.GetRolesAsync(user);

                result.Add(new UserGetDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    ProfilePictureUrl = user.ProfilePictureUrl,
                    IsDeleted = user.IsDeleted,
                    Roles = roles
                });
            }

            return result;
        }
    }
}
