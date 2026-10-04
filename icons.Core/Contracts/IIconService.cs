using icons.Core.Dtos.Icon;
using icons.Data.Enums;

namespace icons.Core.Contracts
{
    public interface IIconService
    {
        Task<IEnumerable<IconGetDto>> GetAllIconsAsync();
        Task<IEnumerable<IconGetDto>> GetAllIconsSortedAsync(EnumIconSortOptions sort);
        Task<IEnumerable<IconGetDto>> GetAllIconsByUserIdAsync(string userId);
        Task<IEnumerable<IconGetDto>> GetTop3IconsAsync();
        Task<IconGetDescriptionDto?> GetIconByIdAsync(int id);
        Task AddIconAsync(IconCreateDto icon);
        Task<bool> UpdateIconAsync(int id, IconUpdateDto icon);
        Task<bool> DeleteIconAsync(int id);
    }
}
