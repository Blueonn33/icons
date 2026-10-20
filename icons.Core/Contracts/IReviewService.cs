using icons.Core.ViewModels.Reviews;
using icons.Data.Enums;

namespace icons.Core.Contracts
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewViewModel>> GetAllReviewsByIconIdSortedAsync(int id, EnumReviewSortOptions sort);
        Task<IEnumerable<ReviewUserProfileViewModel>> GetAllReviewsByUserIdAsync(string userId);
        Task<ReviewViewModel?> GetReviewByIdAsync(int id);
        Task AddReviewAsync(ReviewInputModel review);
        Task<bool> UpdateReviewAsync(int id, ReviewInputModel review);
        Task<bool> DeleteReviewAsync(int id);
    }
}
