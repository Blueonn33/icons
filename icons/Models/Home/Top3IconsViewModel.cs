using icons.Models.Icons;

namespace icons.Models.Home
{
    public class Top3IconsViewModel
    {
        public IEnumerable<IconViewModel> Top3Icons { get; set; } = new List<IconViewModel>();
    }
}
