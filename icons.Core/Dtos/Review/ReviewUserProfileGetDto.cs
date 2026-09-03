using icons.Data.Enums;

namespace icons.Core.Dtos.Review
{
    public class ReviewUserProfileGetDto
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

        public EnumReviewRating Rating
        {
            get; set;
        }

        public DateTime PublishedTime
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
