using AutoMapper;
using icons.Core.DTO.Messages.Request;
using icons.Core.DTO.Messages.Response;
using icons.Data.Models;

namespace icons.Core.Mappings
{
    public class MessagesProfile : Profile
    {
        public MessagesProfile()
        {
            CreateMap<AddMessageRequestData, Message>();
            CreateMap<Message, GetMessageResponseData>();
        }
    }
}
