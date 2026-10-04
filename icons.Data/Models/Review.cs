using icons.Data.Common;
using icons.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static icons.Data.Constants.ValidationConstants;

namespace icons.Data.Models
{
    public class Review : IEntity
    {
        [Key]
        public int Id
        {
            get; set;
        }

        [Required]
        [StringLength(ReviewTitleMaxLength, MinimumLength = ReviewTitleMinLength)]
        public string Title
        {
            get; set;
        } = null!;

        [Required]
        [StringLength(ReviewDescriptionMaxLength, MinimumLength = ReviewDescriptionMinLength)]
        public string Description
        {
            get; set;
        } = null!;

        [Required]
        public EnumReviewRating? Rating
        {
            get; set;
        }

        public DateTime PublishedTime
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

        [ForeignKey(nameof(Icon))]
        public int IconId
        {
            get; set;
        }

        public virtual Icon Icon
        {
            get; set;
        } = null!;

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId
        {
            get;
            set;
        } = null!;

        public virtual ApplicationUser User
        {
            get; set;
        } = null!;
    }
}
