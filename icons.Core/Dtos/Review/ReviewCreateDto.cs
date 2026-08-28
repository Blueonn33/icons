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
        [StringLength(ReviewUserProfilePictureUrlLength)]
        public string UserProfilePictureUrl
        {
            get; set;
        } = null!;

        [Required]
        [MinLength(ReviewUsernameMinLength)]
        [MaxLength(ReviewUsernameMaxLength)]
        public string Username
        {
            get; set;
        } = null!;

        [Required]
        public string UserId
        {
            get;
            set;
        } = null!;
    }
}
