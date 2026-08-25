using icons.Core.Contracts;
using icons.Core.Dtos.Review;
using icons.Core.Enums;
using icons.Data.Common;
using icons.Data.Models;

namespace icons.Core.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _repository;

        public ReviewService(IReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task AddReviewAsync(ReviewCreateDto review)
        {
            var newReview = new Review
            {
                Title = review.Title,
                Description = review.Description,
                Rating = review.Rating,
                IconId = review.IconId,
                UserId = review.UserId
            };

            await _repository.AddAsync(newReview);
            await _repository.SaveAsync();
        }

        public async Task DeleteReviewAsync(int id)
        {
            var review = await _repository.GetByIdAsync(id);

            if (review == null)
            {
                throw new KeyNotFoundException($"Review with id {id} was not found");
            }

            _repository.Delete(review);
        }

        public async Task<IEnumerable<ReviewGetDto>> GetAllReviewsByIconIdAsync(int id)
        {
            var icon = await _repository.GetByIdAsync(id);

            if (icon == null)
            {
                throw new KeyNotFoundException($"Icon with id {id} was not found");
            }

            var reviews = await _repository.GetAllReviewsByIconIdAsync(id);

            return reviews.Select(r => new ReviewGetDto
            {
                Title = r.Title,
                Description = r.Description,
                Rating = r.Rating,
                PublishedTime = r.PublishedTime,
                Username = r.Username,
                UserProfilePictureUrl = r.UserProfilePictureUrl
            });
        }

        public async Task<IEnumerable<ReviewGetDto>> GetAllReviewsByIconIdSortedAsync(int id, EnumReviewSortOptions sort)
        {
            var icon = await _repository.GetByIdAsync(id);

            if (icon == null)
            {
                throw new KeyNotFoundException($"Icon with id {id} was not found");
            }

            var reviews = await _repository.GetAllReviewsByIconIdSortedAsync(id, sort);

            return reviews.Select(r => new ReviewGetDto
            {
                Title = r.Title,
                Description = r.Description,
                Rating = r.Rating,
                PublishedTime = r.PublishedTime,
                Username = r.Username,
                UserProfilePictureUrl = r.UserProfilePictureUrl
            });
        }

        public Task<ReviewGetDto?> GetReviewByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateReviewAsync(int id, ReviewUpdateDto review)
        {
            throw new NotImplementedException();
        }
    }
}
