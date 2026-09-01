using icons.Core.Dtos.Review;
using icons.Core.Enums;

namespace icons.Models.Reviews
{
    public class ReviewsViewModel
    {
        public IEnumerable<ReviewGetDto> Reviews { get; set; } = new List<ReviewGetDto>();

        public int IconId
        {
            get; set;
        }

        public string UserId
        {
            get; set;
        } = null!;

        public EnumReviewSortOptions Sort { get; set; }
    }
}
