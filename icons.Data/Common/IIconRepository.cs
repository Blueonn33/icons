using icons.Data.Models;

namespace icons.Data.Common
{
    public interface IIconRepository : IRepository<Icon>
    {
        Task<IEnumerable<Icon>> GetAllIconsAsync();
        Task<IEnumerable<Icon>> GetAllIconsByUserIdAsync(string userId);
        Task<IEnumerable<Icon>> GetTop3IconsAsync();
        Task<Icon> GetIconWithReviewsByIdAsync(int id);
    }
}
