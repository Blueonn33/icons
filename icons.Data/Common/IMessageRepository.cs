using icons.Data.Models;

namespace icons.Data.Common
{
    public interface IMessageRepository : IRepository<Message>
    {
        Task<IEnumerable<Message>> GetAllMessagesByChatIdsAsync(string senderId, string receiverId);
    }
}
