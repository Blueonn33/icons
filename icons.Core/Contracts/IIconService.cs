using icons.Data.Models;

namespace icons.Core.Contracts
{
    public interface IIconService
    {
        Task<IEnumerable<Icon>> GetAllIconsAsync();
        Task<IEnumerable<Icon>> GetAllIconsByUserIdAsync(string userId);
        Task<IEnumerable<Icon>> GetTop3IconsAsync();
        Task<Icon> GetIconByIdAsync(int id);
        Task AddIconAsync(Icon icon);
        void UpdateIcon(Icon icon);
        void DeleteIcon(Icon icon);
    }
}
