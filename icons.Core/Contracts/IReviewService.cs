using icons.Core.Dtos.Review;

namespace icons.Core.Contracts
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewGetDto>> GetAllReviewsByIconIdAsync(int id);
        Task<ReviewGetDto?> GetReviewByIdAsync(int id);
        Task AddReviewAsync(ReviewCreateDto review);
        Task UpdateReviewAsync(int id, ReviewUpdateDto review);
        Task DeleteReviewAsync(int id);

        // TODO: Sort Reviews
    }
}
