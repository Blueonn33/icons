using icons.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace icons.Data.Common
{
    public class MessageRepository(ApplicationDbContext context) : Repository<Message>(context), IMessageRepository
    {
        public async Task<IEnumerable<Message>> GetAllMessagesByChatIdsAsync(string senderId, string receiverId)
        {
            return await context.Messages
                .Where(m => m.SenderId == senderId && m.ReceiverId == receiverId)
                .Include(m => m.Receiver)
                .Include(m => m.Sender)
                .OrderBy(m => m.SentTime)
                .ToListAsync();
        }
    }
}
