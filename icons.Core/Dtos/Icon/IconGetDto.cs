namespace icons.Core.Dtos.Icon
{
    public class IconGetDto
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
