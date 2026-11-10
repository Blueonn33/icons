using icons.Core.DTO.Notes.Request;
using icons.Core.DTO.Notes.Response;

namespace icons.Core.Contracts
{
    public interface INoteService
    {
        Task<GetAllNotesResponseData> GetAllNotesByUserIdAsync(string userId);
        Task AddNoteAsync(AddNoteRequestData requestData);
    }
}
