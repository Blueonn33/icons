using System.ComponentModel.DataAnnotations;
using static icons.Data.Constants.ValidationConstants;

namespace icons.Core.Dtos.Icon
{
    public class IconUpdateDto
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
    }
}
