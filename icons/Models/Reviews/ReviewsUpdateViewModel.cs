using System.ComponentModel.DataAnnotations;
using static icons.Data.Constants.ValidationConstants;

namespace icons.Models.Reviews
{
    public class ReviewsUpdateViewModel
    {
        [Key]
        public int Id
        {
            get; set;
        }

        [StringLength(ReviewTitleMaxLength, MinimumLength = ReviewTitleMinLength)]
        public string Title
        {
            get; set;
        } = null!;

        [StringLength(ReviewDescriptionMaxLength, MinimumLength = ReviewDescriptionMinLength)]
        public string Description
        {
            get; set;
        } = null!;
    }
}
