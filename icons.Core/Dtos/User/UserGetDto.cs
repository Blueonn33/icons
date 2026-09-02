namespace icons.Core.Dtos.User
{
    public class UserGetDto
    {
        public string Id
        {
            get; set;
        } = null!;

        public string ProfilePictureUrl
        {
            get;
            set;
        } = null!;

        public string Name
        {
            get; set;
        } = null!;

        public string Username
        {
            get; set;
        } = null!;

        public bool IsDeleted
        {
            get; set;
        }

        public IEnumerable<string> Roles
        {
            get; set;
        }
    }
}