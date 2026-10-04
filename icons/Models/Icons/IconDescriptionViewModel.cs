using icons.Core.Enums;
using icons.Data.Enums;
using icons.Models.Reviews;

namespace icons.Models.Icons
{
    public class IconDescriptionViewModel
    {
        public int Id
        {
            get; set;
        }

        public string ImageUrl
        {
            get; set;
        } = null!;

        public string Title
        {
            get; set;
        } = null!;

        public string? Description
        {
            get; set;
        }

        public double AverageRating
        {
            get; set;
        }

        public DateTime PublishedTime
        {
            get; set;
        }

        public string Username
        {
            get; set;
        } = null!;

        public string UserProfilePictureUrl
        {
            get; set;
        } = null!;

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

        public IEnumerable<ReviewViewModel> Reviews
        {
            get; set;
        } = new List<ReviewViewModel>();

        public EnumReviewSortOptions Sort
        {
            get; set;
        }
    }
}
