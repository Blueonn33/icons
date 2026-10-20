using AutoMapper;
using icons.Core.Contracts;
using icons.Core.ViewModels.Reviews;
using icons.Data.Common;
using icons.Data.Enums;
using icons.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace icons.Core.Services
{
    public class ReviewService(
        IReviewRepository _repository,
        IIconRepository _iconRepository,
        IUserService _userService,
        UserManager<ApplicationUser> _userManager,
        IMapper _mapper) : IReviewService
    {
        public async Task AddReviewAsync(ReviewInputModel review)
        {
            var user = await _userManager.FindByIdAsync(review.UserId);

            if (user == null)
            {
                throw new KeyNotFoundException($"Потребителят не е открит");
            }

            var newReview = new Review
            {
                Title = review.Title,
                Description = review.Description,
                Rating = review.Rating,
                IconId = review.IconId,
                Username = review.Username,
                UserProfilePictureUrl = review.UserProfilePictureUrl,
                UserId = review.UserId
            };

            await _repository.AddAsync(newReview);
            await _repository.SaveAsync();

            var icon = await _iconRepository.GetIconWithReviewsByIdAsync(newReview.IconId);
            icon.AverageRating = icon.Reviews.Any()
                ? icon.Reviews.Average(r => (int)r.Rating)
                : 0;

            await _iconRepository.SaveAsync();

            user.Elixir += 5;
            await _userService.UpdateRankAsync(user);
        }

        public async Task<bool> DeleteReviewAsync(int id)
        {
            if (id <= 0)
            {
                return false;
            }

            var review = await _repository.GetByIdAsync(id);

            if (review == null)
            {
                return false;
            }

            _repository.Delete(review);
            await _repository.SaveAsync();

            var icon = await _iconRepository.GetIconWithReviewsByIdAsync(review.IconId);
            icon.AverageRating = icon.Reviews.Any()
                ? icon.Reviews.Average(r => (int)r.Rating)
                : 0;

            await _iconRepository.SaveAsync();
            return true;
        }

        public async Task<IEnumerable<ReviewViewModel>> GetAllReviewsByIconIdSortedAsync(int id, EnumReviewSortOptions sort)
        {
            var icon = await _iconRepository.GetByIdAsync(id);

            if (icon == null)
            {
                throw new KeyNotFoundException($"Икона с ID: {id} не е открита");
            }

            var reviews = await _repository.GetAllReviewsByIconIdSortedAsync(id, sort);

            return reviews.Select(r => new ReviewViewModel()
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
            });
        }

        public async Task<IEnumerable<ReviewUserProfileViewModel>> GetAllReviewsByUserIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new KeyNotFoundException($"Потребителят не е открит");
            }

            var reviews = await _repository.GetAllReviewsByUserIdAsync(userId);

            return _mapper.Map<IEnumerable<ReviewUserProfileViewModel>>(reviews);
        }

        public async Task<ReviewViewModel?> GetReviewByIdAsync(int id)
        {
            var review = await _repository.GetReviewByIdAsync(id);

            if (review == null)
            {
                throw new KeyNotFoundException($"Ревю с ID: {id} не е открито");
            }

            return new ReviewViewModel()
            {
                Id = review.Id,
                Title = review.Title,
                Description = review.Description,
                IconId = review.IconId,
                PublishedTime = review.PublishedTime,
                Rank = review.User.Rank,
                RankImageUrl = _userService.GetRankImage(review.User.Rank),
                Rating = review.Rating,
                UserId = review.UserId,
                Username = review.Username
            };
        }

        public async Task<bool> UpdateReviewAsync(int id, ReviewInputModel review)
        {
            if (id <= 0)
            {
                return false;
            }

            var updateReview = await _repository.GetByIdAsync(id);

            if (updateReview == null)
            {
                return false;
            }

            updateReview.Title = review.Title;
            updateReview.Description = review.Description;

            _repository.Update(updateReview);
            await _repository.SaveAsync();
            return true;
        }
    }
}
