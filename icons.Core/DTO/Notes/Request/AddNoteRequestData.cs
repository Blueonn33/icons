namespace icons.Core.DTO.Notes.Request
{
    public class AddNoteRequestData
    {
        public string Content
        {
            get; set;
        } = null!;

        public string SenderId
        {
            get; set;
        } = null!;

        public string ReceiverId
        {
            get; set;
        } = null!;
    }
}
