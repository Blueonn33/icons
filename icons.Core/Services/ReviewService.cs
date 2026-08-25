using icons.Core.Contracts;
using icons.Core.Dtos.Review;
using icons.Data.Common;
using icons.Data.Enums;
using icons.Data.Models;

namespace icons.Core.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IRepository<Review> _repository;

        public ReviewService(IRepository<Review> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ReviewGetDto>> GetAllReviewsByIconIdAsync(int id)
        {
            var icon = await _repository.GetByIdAsync(id);

            if (icon == null)
            {
                throw new KeyNotFoundException($"Icon with id {id} was not found");
            }

            var reviews = await _repository.GetAllAsync();

            return reviews
                .Where(r => r.IconId == id)
                .Select(r => new ReviewGetDto
            {
                Id = r.Id,
                Title = r.Title,
                Description = r.Description,
                Rating = r.Rating,
                PublishedTime = r.PublishedTime,
                Username = r.Username,
                UserProfilePictureUrl = r.UserProfilePictureUrl,
            });
        }

        public Task<IEnumerable<ReviewGetDto>> GetAllReviewsByIconIdSortedAsync(int id, EnumReviewRating sort)
        {
            throw new NotImplementedException();
        }

        public Task<ReviewGetDto?> GetReviewByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddReviewAsync(ReviewCreateDto review)
        {
            throw new NotImplementedException();
        }

        public Task UpdateReviewAsync(int id, ReviewUpdateDto review)
        {
            throw new NotImplementedException();
        }

        public Task DeleteReviewAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
