using icons.Core.Contracts;
using icons.Core.Dtos.Review;
using icons.Core.Enums;
using icons.Data;
using icons.Data.Common;
using icons.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace icons.Core.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _repository;
        private readonly IIconRepository _iconRepository;
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReviewService(IReviewRepository repository, IIconRepository iconRepository, IUserService userService, UserManager<ApplicationUser> userManager)
        {
            _repository = repository;
            _iconRepository = iconRepository;
            _userService = userService;
            _userManager = userManager;
        }

        public async Task AddReviewAsync(ReviewCreateDto review)
        {
            var user = await _userManager.FindByIdAsync(review.UserId);

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

        public async Task DeleteReviewAsync(int id)
        {
            var review = await _repository.GetByIdAsync(id);

            if (review == null)
            {
                throw new KeyNotFoundException($"Review with id {id} was not found");
            }

            _repository.Delete(review);
            await _repository.SaveAsync();

            var icon = await _iconRepository.GetIconWithReviewsByIdAsync(review.IconId);
            icon.AverageRating = icon.Reviews.Any()
                ? icon.Reviews.Average(r => (int)r.Rating)
                : 0;

            await _iconRepository.SaveAsync();
        }

        public async Task<IEnumerable<ReviewGetDto>> GetAllReviewsByIconIdAsync(int id)
        {
            var icon = await _iconRepository.GetByIdAsync(id);

            if (icon == null)
            {
                throw new KeyNotFoundException($"Icon with id {id} was not found");
            }

            var reviews = await _repository.GetAllReviewsByIconIdAsync(id);

            return reviews.Select(r => new ReviewGetDto
            {
                Id = r.Id,
                Title = r.Title,
                Description = r.Description,
                Rating = r.Rating,
                PublishedTime = r.PublishedTime,
                Username = r.Username,
                UserProfilePictureUrl = r.UserProfilePictureUrl,
                UserId = r.UserId,
                IconId = r.IconId
            });
        }

        public async Task<IEnumerable<ReviewGetDto>> GetAllReviewsByIconIdSortedAsync(int id, EnumReviewSortOptions sort)
        {
            var icon = await _iconRepository.GetByIdAsync(id);

            if (icon == null)
            {
                throw new KeyNotFoundException($"Icon with id {id} was not found");
            }

            var reviews = await _repository.GetAllReviewsByIconIdSortedAsync(id, sort);

            return reviews.Select(r => new ReviewGetDto
            {
                Id = r.Id,
                Title = r.Title,
                Description = r.Description,
                Rating = r.Rating,
                PublishedTime = r.PublishedTime,
                Username = r.Username,
                UserProfilePictureUrl = r.UserProfilePictureUrl,
                UserId = r.UserId,
                IconId = r.IconId
            });
        }

        public async Task<ReviewGetDto?> GetReviewByIdAsync(int id)
        {
            var review = await _repository.GetByIdAsync(id);

            if (review == null)
            {
                throw new KeyNotFoundException($"Review with id {id} was not found");
            }

            return new ReviewGetDto
            {
                Id = review.Id,
                Title = review.Title,
                Description = review.Description,
                Rating = review.Rating,
                PublishedTime = review.PublishedTime,
                Username = review.Username,
                UserProfilePictureUrl = review.UserProfilePictureUrl,
                UserId = review.UserId,
                IconId = review.IconId
            };
        }

        public async Task UpdateReviewAsync(int id, ReviewUpdateDto review)
        {
            var updateReview = await _repository.GetByIdAsync(id);

            if (updateReview == null)
            {
                throw new KeyNotFoundException($"Review with id {id} was not found");
            }

            updateReview.Title = review.Title;
            updateReview.Description = review.Description;

            _repository.Update(updateReview);
            await _repository.SaveAsync();
        }
    }
}
