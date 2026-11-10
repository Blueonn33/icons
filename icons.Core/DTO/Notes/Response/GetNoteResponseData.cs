namespace icons.Core.DTO.Notes.Response
{
    public class GetNoteResponseData
    {
        public int Id
        {
            get; set;
        }

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
