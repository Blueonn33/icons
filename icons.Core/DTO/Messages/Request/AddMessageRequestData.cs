namespace icons.Core.DTO.Messages.Request
{
    public class AddMessageRequestData
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
