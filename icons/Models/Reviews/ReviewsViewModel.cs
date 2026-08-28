using icons.Core.Dtos.Review;

namespace icons.Models.Reviews
{
    public class ReviewsViewModel
    {
        public IEnumerable<ReviewGetDto> Reviews { get; set; } = new List<ReviewGetDto>();

        public int IconId
        {
            get; set;
        }
    }
}
