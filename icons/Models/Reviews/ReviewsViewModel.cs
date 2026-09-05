using icons.Core.Dtos.Review;
using icons.Core.Enums;
using icons.Data.Enums;

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

        public string RankImageUrl
        {
            get;
            set;
        } = null!;

        public EnumUserElixirRank Rank
        {
            get; set;
        }

        public EnumReviewSortOptions Sort
        {
            get; set;
        }
    }
}
