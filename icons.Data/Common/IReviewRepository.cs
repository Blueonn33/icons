using icons.Core.Enums;
using icons.Data.Models;

namespace icons.Data.Common
{
    public interface IReviewRepository : IRepository<Review>
    {
        Task<IEnumerable<Review>> GetAllReviewsByIconIdAsync(int id);
        Task<IEnumerable<Review>> GetAllReviewsByIconIdSortedAsync(int id, EnumReviewSortOptions sort);
    }
}
