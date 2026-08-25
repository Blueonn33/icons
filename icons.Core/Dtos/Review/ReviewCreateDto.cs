using icons.Data.Enums;
using System.ComponentModel.DataAnnotations;
using static icons.Data.Constants.ValidationConstants;

namespace icons.Core.Dtos.Review
{
    public class ReviewCreateDto
    {
        [Required]
        [MinLength(ReviewTitleMinLength)]
        [MaxLength(ReviewTitleMaxLength)]
        public string Title
        {
            get; set;
        }
            = null!;

        [MinLength(ReviewDescriptionMinLength)]
        [MaxLength(ReviewDescriptionMaxLength)]
        public string? Description
        {
            get; set;
        }

        public EnumReviewRating Rating
        {
            get; set;
        }

        public int IconId
        {
            get; set;
        }

        [Required]
        public string UserId
        {
            get;
            set;
        } = null!;
    }
}
