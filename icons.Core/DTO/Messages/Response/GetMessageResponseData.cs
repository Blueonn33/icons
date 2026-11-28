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

        public DateTime SentTime
        {
            get; set;
        }

        public string SenderId
        {
            get; set;
        } = null!;
    }
}
