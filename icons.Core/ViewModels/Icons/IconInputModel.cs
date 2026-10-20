using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static icons.Data.Constants.ValidationConstants;

namespace icons.Core.ViewModels.Icons
{
    public class IconInputModel
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

        [Required(ErrorMessage = "Прикачи снимка")]
        public IFormFile ImageFile
        {
            get; set;
        } = null!;

        public string ImageUrl
        {
            get; set;
        } = null!;

        [Required(ErrorMessage = "Напиши описание")]
        [StringLength(IconDescriptionMaxLength, MinimumLength = IconDescriptionMinLength, ErrorMessage = "Дължината трябва да е между {2} и {1} символа")]
        public string Description
        {
            get; set;
        } = null!;

        public string UserId
        {
            get; set;
        } = null!;
    }
}
