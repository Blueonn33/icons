using icons.Data.Models;

namespace icons.Data.Common
{
    public interface INoteRepository : IRepository<Note>
    {
        Task<IEnumerable<Note>> GetAllNotesByUserIdAsync(string userId);
    }
}
