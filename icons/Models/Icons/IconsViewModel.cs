using icons.Core.Dtos.Icon;

namespace icons.Models.Icons
{
    public class IconsViewModel
    {
        public IEnumerable<IconGetDto> GetAllIcons { get; set; } = new List<IconGetDto>();

        public string UserId { get; set; } = null!;
    }
}
