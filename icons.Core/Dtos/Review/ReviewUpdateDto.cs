using System.ComponentModel.DataAnnotations;
using static icons.Data.Constants.ValidationConstants;

namespace icons.Core.Dtos.Review
{
    public class ReviewUpdateDto
    {
        [Required]
        [MinLength(ReviewTitleMinLength)]
        [MaxLength(ReviewTitleMaxLength)]
        public string Title
        {
            get; set;
        }
            = null!;

        [MinLength(ReviewDescriptionMinLength)]
        [MaxLength(ReviewDescriptionMaxLength)]
        public string? Description
        {
            get; set;
        }
    }
}
