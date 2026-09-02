using icons.Core.Dtos.Icon;
using icons.Data.Enums;

namespace icons.Models.Icons
{
    public class IconsViewModel
    {
        public IEnumerable<IconGetDto> GetAllIcons { get; set; } = new List<IconGetDto>();

        public string UserId
        {
            get; set;
        } = null!;

        public EnumIconSortOptions Sort
        {
            get; set;
        }
    }
}
