using icons.Core.Dtos.Icon;

namespace icons.Models.Home
{
    public class Top3IconsViewModel
    {
        public IEnumerable<IconGetDto> Top3Icons { get; set; } = new List<IconGetDto>();
    }
}
