namespace icons.Core.Dtos.Icon
{
    public class IconUserProfileGetDto
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

        public DateTime PublishedTime
        {
            get; set;
        }

        public string UserId
        {
            get; set;
        } = null!;
    }
}
