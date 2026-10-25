namespace icons.Core.ViewModels.Icons
{
    public class IconViewModel
    {
        public int Id
        {
            get; set;
        }

        public string ImageUrl
        {
            get; set;
        } = null!;

        public double AverageRating
        {
            get; set;
        }

        public string Title
        {
            get; set;
        } = null!;

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
    }
}
