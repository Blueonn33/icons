namespace icons.Core.DTO.Messages.Response
{
    public class GetMessageResponseData
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
