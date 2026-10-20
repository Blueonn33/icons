using icons.Data.Enums;

namespace icons.Core.ViewModels.Icons
{
    public class IconsAllViewModel
    {
        public IEnumerable<IconViewModel> GetAllIcons { get; set; } = new List<IconViewModel>();

        public EnumIconSortOptions Sort
        {
            get; set;
        }
    }
}
