using icons.Core.Dtos.Review;

namespace icons.Core.Dtos.Icon
{
    public class IconGetDto
    {
        public int Id
        {
            get; set;
        }

        public string ImageUrl
        {
            get; set;
        } = null!;

        public string Title
        {
            get; set;
        } = null!;

        public string? Description
        {
            get; set;
        }

        public double AverageRating
        {
            get; set;
        }

        public string Username
        {
            get; set;
        } = null!;

        public string UserProfilePictureUrl
        {
            get; set;
        } = null!;

        public List<ReviewGetDto> Reviews
        {
            get;
            set;
        } = new List<ReviewGetDto>();
    }
}
