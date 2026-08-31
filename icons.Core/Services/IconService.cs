using icons.Core.Contracts;
using icons.Core.Dtos.Icon;
using icons.Core.Dtos.Review;
using icons.Data;
using icons.Data.Common;
using icons.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace icons.Core.Services
{
    public class IconService : IIconService
    {
        private readonly IIconRepository _repository;
        private readonly UserManager<ApplicationUser> _userManager;

        public IconService(IIconRepository repository, UserManager<ApplicationUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        public async Task<IEnumerable<IconGetDto>> GetAllIconsAsync()
        {
            var icons = await _repository.GetAllIconsAsync();

            return icons.Select(i => new IconGetDto
            {
                Id = i.Id,
                ImageUrl = i.ImageUrl,
                Title = i.Title,
                Description = i.Description,
                AverageRating = i.AverageRating,
                Username = i.Username,
                UserProfilePictureUrl = i.UserProfilePictureUrl
            });
        }

        public async Task<IEnumerable<IconGetDto>> GetAllIconsByUserIdAsync(string userId)
        {
            var icons = await _repository.GetAllIconsByUserIdAsync(userId);

            return icons.Select(i => new IconGetDto
            {
                Id = i.Id,
                ImageUrl = i.ImageUrl,
                Title = i.Title,
                Description = i.Description,
            });
        }

        public async Task<IEnumerable<IconGetDto>> GetTop3IconsAsync()
        {
            var icons = await _repository.GetTop3IconsAsync();

            return icons.Select(i => new IconGetDto
            {
                Id = i.Id,
                ImageUrl = i.ImageUrl,
                Title = i.Title,
                Description = i.Description
            });
        }

        public async Task<IconGetDto?> GetIconByIdAsync(int id)
        {
            var icon = await _repository.GetIconWithReviewsByIdAsync(id);

            if (icon == null)
            {
                throw new KeyNotFoundException($"Icon with Id {id} was not found.");
            }

            return new IconGetDto
            {
                Id = icon.Id,
                ImageUrl = icon.ImageUrl,
                Title = icon.Title,
                Description = icon.Description,
                AverageRating = icon.AverageRating,
                Username = icon.Username,
                UserProfilePictureUrl = icon.UserProfilePictureUrl,
                Reviews = icon.Reviews.Select(r => new ReviewGetDto
                {
                    Id = r.Id,
                    Title = r.Title,
                    Description = r.Description,
                    Rating = r.Rating,
                    PublishedTime = r.PublishedTime,
                    Username = r.Username,
                    UserProfilePictureUrl = r.UserProfilePictureUrl,
                    IconId = r.IconId
                }).ToList()
            };
        }

        public async Task AddIconAsync(IconCreateDto icon)
        {
            var user = await _userManager.FindByIdAsync(icon.UserId);

            if (user == null)
            {
                throw new KeyNotFoundException($"User with Id {icon.UserId} was not found.");
            }

            var newIcon = new Icon
            {
                ImageUrl = icon.ImageUrl,
                Title = icon.Title,
                Description = icon.Description,
                UserId = icon.UserId,
                Username = user.Name,
                UserProfilePictureUrl = user.ProfilePictureUrl,
                AverageRating = 0
            };

            await _repository.AddAsync(newIcon);
            await _repository.SaveAsync();
        }

        public async Task UpdateIconAsync(int id, IconUpdateDto icon)
        {
            var updateIcon = await _repository.GetByIdAsync(id);

            if (updateIcon == null)
            {
                throw new KeyNotFoundException($"Icon with Id {id} was not found.");
            }

            updateIcon.ImageUrl = icon.ImageUrl;
            updateIcon.Title = icon.Title;
            updateIcon.Description = icon.Description;

            _repository.Update(updateIcon);
            await _repository.SaveAsync();
        }

        public async Task DeleteIconAsync(int id)
        {
            var icon = await _repository.GetByIdAsync(id);

            if (icon == null)
            {
                throw new KeyNotFoundException($"Icon with Id {id} was not found.");
            }

            _repository.Delete(icon);
            await _repository.SaveAsync();
        }
    }
}
