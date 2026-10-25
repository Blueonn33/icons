using icons.Data.Enums;

namespace icons.Core.ViewModels.Reviews
{
    public class ReviewsAllViewModel
    {
        public IEnumerable<ReviewViewModel> Reviews { get; set; } = new List<ReviewViewModel>();

        public int IconId
        {
            get; set;
        }

        public EnumReviewSortOptions Sort
        {
            get; set;
        }

        public string UserId
        {
            get; set;
        } = null!;

        public string RankImageUrl
        {
            get; set;
        } = null!;

        public EnumUserElixirRank Rank
        {
            get; set;
        }
    }
}
