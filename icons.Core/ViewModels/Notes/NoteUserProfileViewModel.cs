namespace icons.Core.ViewModels.Notes
{
    public class NoteUserProfileViewModel
    {
        public int Id
        {
            get; set;
        }

        public string Content
        {
            get; set;
        } = null!;

        public string ReceiverId
        {
            get; set;
        } = null!;

        public string SenderId
        {
            get; set;
        } = null!;

        public string UserProfilePicture
        {
            get; set;
        } = null!;
    }
}
