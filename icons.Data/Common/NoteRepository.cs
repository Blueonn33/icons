using icons.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace icons.Data.Common
{
    public class NoteRepository(ApplicationDbContext context) : Repository<Note>(context), INoteRepository
    {
        public async Task<IEnumerable<Note>> GetAllNotesByUserIdAsync(string userId)
        {
            return await context.Notes
                .Where(n => n.ReceiverId == userId)
                .ToListAsync();
        }
    }
}
