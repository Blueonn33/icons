using System.ComponentModel.DataAnnotations;
using static icons.Data.Constants.ValidationConstants;

namespace icons.Core.Dtos.Review
{
    public class ReviewUpdateDto
    {
        [Key]
        public int Id
        {
            get; set;
        }

        [Required]
        [StringLength(ReviewTitleMaxLength, MinimumLength = ReviewTitleMinLength)]
        public string Title
        {
            get; set;
        } = null!;

        [Required]
        [StringLength(ReviewDescriptionMaxLength, MinimumLength = ReviewDescriptionMinLength)]
        public string Description
        {
            get; set;
        } = null!;
    }
}
