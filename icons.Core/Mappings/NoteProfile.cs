using AutoMapper;
using icons.Core.DTO.Notes.Request;
using icons.Core.DTO.Notes.Response;
using icons.Core.ViewModels.Notes;
using icons.Data.Models;

namespace icons.Core.Mappings
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            CreateMap<AddNoteRequestData, Note>();
            CreateMap<Note, GetNoteResponseData>();
            CreateMap<GetNoteResponseData, NoteUserProfileViewModel>();
            CreateMap<Note, NoteUserProfileViewModel>();
        }
    }
}
