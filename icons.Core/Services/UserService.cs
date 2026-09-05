using icons.Core.Contracts;
using icons.Core.Dtos.Icon;
using icons.Core.Dtos.Review;
using icons.Core.Dtos.User;
using icons.Data;
using icons.Data.Enums;
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

        public async Task<UserProfileGetDto> GetUserProfileAsync(string id)
        {
            var user = await _userManager.Users
                .Include(u => u.Icons)
                .Include(u => u.Reviews)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                throw new KeyNotFoundException($"User with Id {id} was not found.");
            }

            return new UserProfileGetDto
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                ProfilePictureUrl = user.ProfilePictureUrl,
                DateRegistered = user.DateRegistered,
                Elixir = user.Elixir,
                Rank = user.Rank,
                Icons = user.Icons.Select(i => new IconUserProfileGetDto()
                {
                    Id = i.Id,
                    Title = i.Title,
                    ImageUrl = i.ImageUrl,
                    PublishedTime = i.PublishedTime,
                    UserId = user.Id,
                }).ToList(),
                Reviews = user.Reviews.Select(r => new ReviewUserProfileGetDto()
                {
                    Id = r.Id,
                    Description = r.Description,
                    IconId = r.IconId,
                    PublishedTime = r.PublishedTime,
                    Rating = r.Rating,
                    Title = r.Title,
                    UserId = r.UserId
                }).ToList()
            };
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

        public string GetRankImage(EnumUserElixirRank rank)
        {
            return rank switch
            {
                EnumUserElixirRank.Newbie => "/img/ranks/newbie.png",
                EnumUserElixirRank.Scout => "/img/ranks/scout.png",
                EnumUserElixirRank.Captain => "/img/ranks/captain.png",
                EnumUserElixirRank.Titan => "/img/ranks/titan.png",
                EnumUserElixirRank.Moderator => "/img/ranks/moderator.png",
                EnumUserElixirRank.Admin => "/img/ranks/admin.png",
                _ => "/img/ranks/flag.png"
            };
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
