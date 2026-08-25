using icons.Core.Dtos.Review;
using icons.Data.Enums;

namespace icons.Core.Contracts
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewGetDto>> GetAllReviewsByIconIdAsync(int id);
        Task<IEnumerable<ReviewGetDto>> GetAllReviewsByIconIdSortedAsync(int id, EnumReviewRating sort);
        Task<ReviewGetDto?> GetReviewByIdAsync(int id);
        Task AddReviewAsync(ReviewCreateDto review);
        Task UpdateReviewAsync(int id, ReviewUpdateDto review);
        Task DeleteReviewAsync(int id);
    }
}
