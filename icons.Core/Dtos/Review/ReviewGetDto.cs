using icons.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace icons.Core.Dtos.Review
{
    public class ReviewGetDto
    {
        [Key]
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

        public string UserProfilePictureUrl
        {
            get; set;
        } = null!;

        public string Username
        {
            get; set;
        } = null!;
    }
}
