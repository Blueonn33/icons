using icons.Data.Enums;

namespace icons.Models.Reviews
{
    public class ReviewUserProfileViewModel
    {
        public int Id
        {
            get; set;
        }

        public string Title
        {
            get; set;
        }
            = null!;

        public string? Description
        {
            get; set;
        }

        public EnumReviewRating? Rating
        {
            get; set;
        }

        public string UserId
        {
            get; set;
        } = null!;

        public int IconId
        {
            get; set;
        }
    }
}
