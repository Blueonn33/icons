using icons.Core.Contracts;
using icons.Core.ViewModels.Home;
using icons.Core.ViewModels.Icons;
using icons.Core.ViewModels.Reviews;
using icons.Data.Common;
using icons.Data.Enums;
using icons.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace icons.Core.Services
{
    public class IconService(
        IIconRepository _repository,
        IUserService _userService,
        UserManager<ApplicationUser> _userManager) : IIconService
    {
        public async Task<IconsAllViewModel> GetAllIconsSortedAsync(EnumIconSortOptions sort)
        {
            var icons = await _repository.GetAllIconsSortedAsync(sort);

            var model = new IconsAllViewModel()
            {
                GetAllIcons = icons.Select(i => new IconViewModel()
                {
                    Id = i.Id,
                    Title = i.Title,
                    ImageUrl = i.ImageUrl,
                    AverageRating = i.AverageRating,
                    UserId = i.User.Id,
                    UserProfilePictureUrl = i.User.ProfilePictureUrl,
                    Username = i.User.Name
                })
            };

            return model;
        }

        public async Task<IEnumerable<IconUserProfileViewModel>> GetAllIconsByUserIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new KeyNotFoundException($"Потребителят не е открит");
            }

            var icons = await _repository.GetAllIconsByUserIdAsync(userId);

            return icons.Select(i => new IconUserProfileViewModel()
            {
                Id = i.Id,
                Title = i.Title,
                ImageUrl = i.ImageUrl,
                UserId = i.User.Id
            });
        }

        public async Task<Top3IconsViewModel> GetTop3IconsAsync()
        {
            var icons = await _repository.GetTop3IconsAsync();

            var model = new Top3IconsViewModel()
            {
                Top3Icons = icons.Select(i => new IconViewModel()
                {
                    Id = i.Id,
                    Title = i.Title,
                    ImageUrl = i.ImageUrl,
                    UserId = i.User.Id,
                    UserProfilePictureUrl = i.User.ProfilePictureUrl,
                    Username = i.User.Name
                })
            };

            return model;
        }

        public async Task<IconDetailsViewModel?> GetIconByIdAsync(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            var icon = await _repository.GetIconWithReviewsByIdAsync(id);

            if (icon == null)
            {
                return null;
            }

            var user = await _userManager.FindByIdAsync(icon.UserId);

            if (user == null)
            {
                return null;
            }

            var averageRating = icon.Reviews.Any()
                ? icon.Reviews.Average(r => (int)r.Rating)
                : 0;

            return new IconDetailsViewModel()
            {
                Id = icon.Id,
                ImageUrl = icon.ImageUrl,
                Title = icon.Title,
                Description = icon.Description,
                AverageRating = averageRating,
                Username = user.Name,
                UserProfilePictureUrl = user.ProfilePictureUrl,
                UserId = icon.UserId,
                Reviews = new ReviewsAllViewModel()
                {
                    Reviews = icon.Reviews.Select(r => new ReviewViewModel()
                    {
                        Id = r.Id,
                        Title = r.Title,
                        Description = r.Description,
                        PublishedTime = r.PublishedTime,
                        IconId = r.IconId,
                        Rank = r.User.Rank,
                        RankImageUrl = _userService.GetRankImage(r.User.Rank),
                        Rating = r.Rating,
                        UserId = r.UserId,
                        Username = r.User.Name,
                        UserProfilePictureUrl = r.User.ProfilePictureUrl
                    }),
                    IconId = icon.Id,
                    UserId = user.Id,
                    Rank = user.Rank,
                    RankImageUrl = _userService.GetRankImage(user.Rank)
                }
            };
        }

        public async Task AddIconAsync(IconInputModel icon)
        {
            var user = await _userManager.FindByIdAsync(icon.UserId);

            if (user == null)
            {
                throw new KeyNotFoundException($"Потребителят не е открит");
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

            user.Elixir += 20;
            await _userService.UpdateRankAsync(user);
        }

        public async Task<bool> UpdateIconAsync(int id, IconUpdateInputModel icon)
        {
            if (id <= 0)
            {
                return false;
            }

            var updateIcon = await _repository.GetByIdAsync(id);

            if (updateIcon == null)
            {
                return false;
            }

            updateIcon.ImageUrl = icon.ImageUrl;
            updateIcon.Title = icon.Title;
            updateIcon.Description = icon.Description;

            _repository.Update(updateIcon);
            await _repository.SaveAsync();

            return true;
        }

        public async Task<bool> DeleteIconAsync(int id)
        {
            if (id <= 0)
            {
                return false;
            }

            var deletingIcon = await _repository.GetByIdAsync(id);

            if (deletingIcon == null)
            {
                return false;
            }

            _repository.Delete(deletingIcon);
            await _repository.SaveAsync();

            return true;
        }
    }
}
