using icons.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static icons.Data.Constants.ValidationConstants;

namespace icons.Data.Models
{
    public class Icon : IEntity
    {
        [Key]
        public int Id
        {
            get; set;
        }

        [Required]
        public string ImageUrl
        {
            get; set;
        } = null!;

        [Required]
        [StringLength(IconTitleMaxLength, MinimumLength = IconTitleMinLength)]
        public string Title
        {
            get; set;
        } = null!;

        [Required]
        [StringLength(IconDescriptionMaxLength, MinimumLength = IconDescriptionMinLength)]
        public string Description
        {
            get; set;
        } = null!;

        [Range(IconAverageRangeMinValue, IconAverageRangeMaxValue)]
        public double AverageRating
        {
            get; set;
        }

        public DateTime PublishedTime
        {
            get; set;
        }

        [Required]
        [StringLength(IconUsernameMaxLength, MinimumLength = IconUsernameMinLength)]
        public string Username
        {
            get; set;
        } = null!;

        [Required]
        [StringLength(UserProfilePictureUrlLength)]
        public string UserProfilePictureUrl
        {
            get;
            set;
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

        public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
    }
}
