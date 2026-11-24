using AutoMapper;
using icons.Core.Contracts;
using icons.Core.DTO.Messages.Request;
using icons.Core.DTO.Messages.Response;
using icons.Data.Common;
using icons.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace icons.Core.Services
{
    public class MessageService(
        UserManager<ApplicationUser> _userManager,
        IMessageRepository _messageRepository,
        IMapper _mapper) : IMessageService
    {
        public async Task AddMessageAsync(AddMessageRequestData requestData)
        {
            var message = _mapper.Map<Message>(requestData);

            await _messageRepository.AddAsync(message);
            await _messageRepository.SaveAsync();
        }

        public async Task<GetAllMessagesResponseData> GetAllMessagesByChatIdsAsync(string senderId, string receiverId)
        {
            var sender = await _userManager.FindByIdAsync(senderId);
            var receiver = await _userManager.FindByIdAsync(receiverId);

            if (sender == null || receiver == null)
            {
                throw new KeyNotFoundException($"Потребителят не е открит");
            }

            var messages = await _messageRepository.GetAllMessagesByChatIdsAsync(senderId, receiverId);
            var messagesDto = _mapper.Map<IEnumerable<GetMessageResponseData>>(messages);

            GetAllMessagesResponseData allMessages = new GetAllMessagesResponseData()
            {
                Messages = messagesDto
            };

            return allMessages;
        }
    }
}
