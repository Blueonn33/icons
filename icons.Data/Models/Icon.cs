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
        [StringLength(IconImageUrlLength)]
        public string ImageUrl
        {
            get; set;
        } = null!;

        [Required]
        [MinLength(IconTitleMinLength)]
        [MaxLength(IconTitleMaxLength)]
        public string Title
        {
            get; set;
        } = null!;

        [MinLength(IconDescriptionMinLength)]
        [MaxLength(IconDescriptionMaxLength)]
        public string? Description
        {
            get; set;
        }

        [Range(IconAverageRangeMinValue, IconAverageRangeMaxValue)]
        public decimal AverageRating
        {
            get; set;
        }

        [Required]
        [MinLength(IconUsernameMinLength)]
        [MaxLength(IconUsernameMaxLength)]
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
