using icons.Core.Contracts;
using icons.Core.DTO.Messages.Response;
using icons.Core.ViewModels.Messages;
using icons.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace icons.Controllers
{
    public class MessagesController(
        IMessageService _messageService,
        UserManager<ApplicationUser> _userManager) : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Index(string receiverId)
        {
            var sender = await _userManager.GetUserAsync(User);
            var receiver = await _userManager.FindByIdAsync(receiverId);

            if (sender == null || receiver == null)
            {
                return NotFound();
            }

            var senderId = sender.Id;
            var messageDtos = await _messageService.GetAllMessagesByChatIdsAsync(senderId, receiverId);

            var messagesList = messageDtos.Messages.Select<GetMessageResponseData, BaseMessageViewModel>(m =>
            {
                if (m.SenderId == senderId)
                {
                    return new MessageSenderViewModel
                    {
                        Content = m.Content,
                        ProfilePic = sender.ProfilePictureUrl!,
                        SentTime = m.SentTime.ToString(new CultureInfo("bg-BG"))
                    };
                }

                return new MessageReceiverViewModel
                {
                    Content = m.Content,
                    ProfilePic = receiver.ProfilePictureUrl!,
                    SentTime = m.SentTime.ToString(new CultureInfo("bg-BG"))
                };
            }).ToList();

            var messages = new AllMessagesViewModel
            {
                Messages = messagesList,
                ReceiverId = receiverId,
                ReceiverName = receiver.Name,
                ReceiverProfilePic = receiver.ProfilePictureUrl!
            };

            return View(messages);
        }
    }
}
