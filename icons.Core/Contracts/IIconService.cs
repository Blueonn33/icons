using icons.Core.Dtos.Icon;

namespace icons.Core.Contracts
{
    public interface IIconService
    {
        Task<IEnumerable<IconGetDto>> GetAllIconsAsync();
        Task<IEnumerable<IconGetDto>> GetAllIconsByUserIdAsync(string userId);
        Task<IEnumerable<IconGetDto>> GetTop3IconsAsync();
        Task<IconGetDto?> GetIconByIdAsync(int id);
        Task AddIconAsync(IconCreateDto icon);
        Task UpdateIconAsync(int id, IconUpdateDto icon);
        Task DeleteIconAsync(int id);
    }
}
