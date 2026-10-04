using icons.Data.Enums;
using System.ComponentModel.DataAnnotations;
using static icons.Data.Constants.ValidationConstants;

namespace icons.Models.Reviews
{
    public class ReviewsCreateViewModel
    {
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

        [Required(ErrorMessage = "Постави оценка")]
        public EnumReviewRating? Rating
        {
            get; set;
        }

        public int IconId
        {
            get; set;
        }

        public string UserId
        {
            get; set;
        } = null!;
    }
}
