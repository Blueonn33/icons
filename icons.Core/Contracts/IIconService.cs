using icons.Core.ViewModels.Home;
using icons.Core.ViewModels.Icons;
using icons.Data.Enums;

namespace icons.Core.Contracts
{
    public interface IIconService
    {
        Task<IconsAllViewModel> GetAllIconsSortedAsync(EnumIconSortOptions sort);
        Task<IEnumerable<IconUserProfileViewModel>> GetAllIconsByUserIdAsync(string userId);
        Task<Top3IconsViewModel> GetTop3IconsAsync();
        Task<IconDetailsViewModel?> GetIconByIdAsync(int id);
        Task AddIconAsync(IconInputModel icon);
        Task<bool> UpdateIconAsync(int id, IconUpdateInputModel icon);
        Task<bool> DeleteIconAsync(int id);
    }
}
