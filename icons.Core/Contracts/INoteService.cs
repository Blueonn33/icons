using icons.Core.DTO.Notes.Request;
using icons.Core.DTO.Notes.Response;

namespace icons.Core.Contracts
{
    public interface INoteService
    {
        Task<GetAllNotesResponseData> GetAllNotesByUserIdAsync(string userId);

        Task<GetNoteResponseData?> GetNoteByIdAsync(int noteId);

        Task AddNoteAsync(AddNoteRequestData requestData);

        Task<bool> DeleteNoteAsync(int id);
    }
}
