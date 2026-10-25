using icons.Core.ViewModels.Icons;
using icons.Core.ViewModels.Reviews;
using icons.Data.Enums;

namespace icons.Core.ViewModels.Users
{
    public class UserProfileViewModel
    {
        public string Id
        {
            get; set;
        } = null!;

        public string Name
        {
            get; set;
        } = null!;

        public string Email
        {
            get; set;
        } = null!;

        public string ProfilePictureUrl
        {
            get; set;
        } = null!;

        public DateTime DateRegistered
        {
            get; set;
        }

        public int Elixir
        {
            get; set;
        }

        public EnumUserElixirRank Rank
        {
            get; set;
        }

        public string RankImageUrl
        {
            get; set;
        } = null!;

        public string IconsCount => Icons.Count().ToString();
        public string ReviewsCount => Reviews.Count().ToString();

        public IEnumerable<IconUserProfileViewModel> Icons { get; set; } = new HashSet<IconUserProfileViewModel>();
        public IEnumerable<ReviewUserProfileViewModel> Reviews { get; set; } = new HashSet<ReviewUserProfileViewModel>();
    }
}
