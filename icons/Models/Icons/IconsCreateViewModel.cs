using System.ComponentModel.DataAnnotations;
using static icons.Data.Constants.ValidationConstants;

namespace icons.Models.Icons
{
    public class IconsCreateViewModel
    {
        [Required]
        [StringLength(IconTitleMaxLength, MinimumLength = IconTitleMinLength)]
        public string Title
        {
            get; set;
        } = null!;

        [Required]
        [Url]
        [StringLength(IconImageUrlLength)]
        public string ImageUrl
        {
            get; set;
        } = null!;

        [Required]
        [StringLength(IconDescriptionMaxLength, MinimumLength = IconDescriptionMinLength)]
        public string Description
        {
            get; set;
        } = null!;
    }
}
