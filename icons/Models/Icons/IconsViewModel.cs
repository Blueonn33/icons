using icons.Data.Enums;

namespace icons.Models.Icons
{
    public class IconsViewModel
    {
        public IEnumerable<IconViewModel> GetAllIcons { get; set; } = new List<IconViewModel>();

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
