namespace icons.Models.Users
{
    public class UserViewModel
    {
        public string Id
        {
            get; set;
        } = null!;

        public string Name
        {
            get; set;
        } = null!;

        public string Email
        {
            get; set;
        } = null!;

        public string ProfilePictureUrl
        {
            get; set;
        } = null!;

        public IEnumerable<string> Roles
        {
            get;
            set;
        } = new List<string>();
    }
}
