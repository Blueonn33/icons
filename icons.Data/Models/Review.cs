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

        public DateTime PublishedTime { get; set; } = DateTime.Now;

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
