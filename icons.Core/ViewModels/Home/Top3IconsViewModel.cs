using icons.Core.ViewModels.Icons;

namespace icons.Core.ViewModels.Home
{
    public class Top3IconsViewModel
    {
        public IEnumerable<IconViewModel> Top3Icons { get; set; } = new List<IconViewModel>();
    }
}
