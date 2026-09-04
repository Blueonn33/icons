using icons.Core.Dtos.Icon;
using icons.Core.Dtos.Review;

namespace icons.Core.Dtos.User
{
    public class UserProfileGetDto
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

        public string IconsCount => Icons.Count.ToString();
        public string ReviewsCount => Reviews.Count.ToString();

        public ICollection<IconUserProfileGetDto> Icons { get; set; } = new HashSet<IconUserProfileGetDto>();
        public ICollection<ReviewUserProfileGetDto> Reviews { get; set; } = new HashSet<ReviewUserProfileGetDto>();
    }
}
