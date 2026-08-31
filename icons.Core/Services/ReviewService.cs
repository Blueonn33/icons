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
        private readonly IIconRepository _iconRepository;

        public ReviewService(IReviewRepository repository, IIconRepository iconRepository)
        {
            _repository = repository;
            _iconRepository = iconRepository;
        }

        public async Task AddReviewAsync(ReviewCreateDto review)
        {
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
