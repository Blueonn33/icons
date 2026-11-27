using AutoMapper;
using icons.Core.Contracts;
using icons.Core.DTO.Notes.Request;
using icons.Core.DTO.Notes.Response;
using icons.Data.Common;
using icons.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace icons.Core.Services
{
    public class NoteService(
        INoteRepository _noteRepository,
        UserManager<ApplicationUser> _userManager,
        IMapper _mapper) : INoteService
    {
        public async Task<GetNoteResponseData?> GetNoteByIdAsync(int noteId)
        {
            var note = await _noteRepository.GetByIdAsync(noteId);
            var noteDto = _mapper.Map<GetNoteResponseData>(note);

            return noteDto;
        }

        public async Task AddNoteAsync(AddNoteRequestData requestData)
        {
            var note = _mapper.Map<Note>(requestData);

            await _noteRepository.AddAsync(note);
            await _noteRepository.SaveAsync();
        }

        public async Task<bool> DeleteNoteAsync(int id)
        {
            var note = await _noteRepository.GetByIdAsync(id);

            if (note == null)
            {
                return false;
            }

            _noteRepository.Delete(note);
            await _noteRepository.SaveAsync();

            return true;
        }

        public async Task<GetAllNotesResponseData> GetAllNotesByUserIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new KeyNotFoundException($"Потребителят не е открит");
            }

            var notes = await _noteRepository.GetAllNotesByUserIdAsync(userId);
            var notesDto = _mapper.Map<IEnumerable<GetNoteResponseData>>(notes);

            GetAllNotesResponseData allNotes = new GetAllNotesResponseData()
            {
                Notes = notesDto
            };

            return allNotes;
        }
    }
}
