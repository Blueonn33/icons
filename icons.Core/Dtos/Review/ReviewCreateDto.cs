using icons.Data.Enums;
using System.ComponentModel.DataAnnotations;
using static icons.Data.Constants.ValidationConstants;

namespace icons.Core.Dtos.Review
{
    public class ReviewCreateDto
    {
        [Required]
        [StringLength(ReviewTitleMaxLength, MinimumLength = ReviewTitleMinLength)]
        public string Title
        {
            get; set;
        }
            = null!;

        [Required]
        [StringLength(ReviewDescriptionMaxLength, MinimumLength = ReviewDescriptionMinLength)]
        public string Description
        {
            get;
            set;
        } = null!;

        [Required]
        public EnumReviewRating? Rating
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
        [StringLength(ReviewUsernameMaxLength, MinimumLength = ReviewUsernameMinLength)]
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
