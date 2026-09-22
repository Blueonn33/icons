using icons.Data.Enums;
using icons.Models.Icons;
using icons.Models.Reviews;

namespace icons.Models.Users
{
    public class UserProfileViewModel
    {
        public string Id
        {
            get;
            set;
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
            get;
            set;
        } = null!;

        public string IconsCount => Icons.Count().ToString();
        public string ReviewsCount => Reviews.Count().ToString();

        public IEnumerable<IconViewModel> Icons { get; set; } = new HashSet<IconViewModel>();
        public IEnumerable<ReviewUserProfileViewModel> Reviews { get; set; } = new HashSet<ReviewUserProfileViewModel>();
    }
}
