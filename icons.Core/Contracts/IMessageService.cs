using icons.Core.DTO.Messages.Request;
using icons.Core.DTO.Messages.Response;

namespace icons.Core.Contracts
{
    public interface IMessageService
    {
        Task<GetAllMessagesResponseData> GetAllMessagesByChatIdsAsync(string senderId, string receiverId);

        Task AddMessageAsync(AddMessageRequestData requestData);
    }
}
