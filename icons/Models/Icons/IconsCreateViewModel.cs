using System.ComponentModel.DataAnnotations;
using static icons.Data.Constants.ValidationConstants;

namespace icons.Models.Icons
{
    public class IconsCreateViewModel
    {
        [Required(ErrorMessage = "Въведи заглавие")]
        [StringLength(IconTitleMaxLength, MinimumLength = IconTitleMinLength, ErrorMessage = "Дължината трябва да е между {2} и {1} символа")]
        public string Title
        {
            get; set;
        } = null!;

        [Required(ErrorMessage = "Прикачи снимка")]
        public IFormFile ImageFile
        {
            get;
            set;
        } = null!;

        [Required(ErrorMessage = "Напиши описание")]
        [StringLength(IconDescriptionMaxLength, MinimumLength = IconDescriptionMinLength, ErrorMessage = "Дължината трябва да е между {2} и {1} символа")]
        public string Description
        {
            get; set;
        } = null!;
    }
}
