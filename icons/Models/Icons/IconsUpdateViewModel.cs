using System.ComponentModel.DataAnnotations;
using static icons.Data.Constants.ValidationConstants;

namespace icons.Models.Icons
{
    public class IconsUpdateViewModel
    {
        public int Id
        {
            get; set;
        }

        [Required(ErrorMessage = "Въведи заглавие")]
        [StringLength(IconTitleMaxLength, MinimumLength = IconTitleMinLength, ErrorMessage = "Дължината трябва да е между {2} и {1} символа")]
        public string Title
        {
            get; set;
        } = null!;

        public IFormFile? ImageFile
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Напиши описание")]
        [StringLength(IconDescriptionMaxLength, MinimumLength = IconDescriptionMinLength, ErrorMessage = "Дължината трябва да е между {2} и {1} символа")]
        public string Description
        {
            get; set;
        } = null!;
    }
}
