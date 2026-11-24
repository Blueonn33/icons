namespace icons.Core.DTO.Messages.Response
{
    public class GetAllMessagesResponseData
    {
        public IEnumerable<GetMessageResponseData> Messages { get; set; } = new List<GetMessageResponseData>();
    }
}
