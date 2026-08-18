using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static icons.Data.Constants.ValidationConstants;

namespace icons.Data.Models
{
    public class Icon
    {
        [Key]
        public int IconId
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

        [Required]
        [MinLength(IconUsernameMinLength)]
        [MaxLength(IconUsernameMaxLength)]
        public string Username
        {
            get; set;
        } = null!;

        [ForeignKey(nameof(User))]
        public int UserId
        {
            get; set;
        }

        public virtual ApplicationUser User
        {
            get; set;
        } = null!;

        public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
    }
}
