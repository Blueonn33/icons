using System.ComponentModel.DataAnnotations;
using static icons.Data.Constants.ValidationConstants;

namespace icons.Models.Reviews
{
    public class ReviewsUpdateViewModel
    {
        public int Id
        {
            get; set;
        }

        [Required(ErrorMessage = "Въведи заглавие")]
        [StringLength(ReviewTitleMaxLength, MinimumLength = ReviewTitleMinLength, ErrorMessage = "Дължината трябва да е между {2} и {1}")]
        public string Title
        {
            get; set;
        }
            = null!;

        [Required(ErrorMessage = "Напиши описание")]
        [StringLength(ReviewDescriptionMaxLength, MinimumLength = ReviewDescriptionMinLength, ErrorMessage = "Дължината трябва да е между {2} и {1}")]
        public string Description
        {
            get;
            set;
        } = null!;
    }
}
