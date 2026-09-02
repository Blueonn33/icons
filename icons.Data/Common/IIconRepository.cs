using icons.Data.Enums;
using icons.Data.Models;

namespace icons.Data.Common
{
    public interface IIconRepository : IRepository<Icon>
    {
        Task<IEnumerable<Icon>> GetAllIconsAsync();
        Task<IEnumerable<Icon>> GetAllIconsSortedAsync(EnumIconSortOptions sort);
        Task<IEnumerable<Icon>> GetAllIconsByUserIdAsync(string userId);
        Task<IEnumerable<Icon>> GetTop3IconsAsync();
        Task<Icon?> GetIconWithReviewsByIdAsync(int id);
    }
}
