using icons.Core.Contracts;
using icons.Core.DTO.Messages.Request;
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
        UserManager<ApplicationUser> _userManager,
        ILogger<MessagesController> _logger) : BaseController
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

        [HttpPost]
        public async Task<IActionResult> CreateMessage(MessageInputModel model)
        {
            var sender = await _userManager.GetUserAsync(User);
            var receiver = await _userManager.FindByIdAsync(model.ReceiverId);

            if (sender == null || receiver == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index), new
                {
                    receiverId = model.ReceiverId
                });
            }

            try
            {
                var message = new AddMessageRequestData()
                {
                    Content = model.Content,
                    SenderId = sender.Id,
                    ReceiverId = model.ReceiverId
                };

                await _messageService.AddMessageAsync(message);
            }
            catch (Exception e)
            {
                _logger.LogCritical("Възникна грешка. Провери logs");
                TempData["Error"] = "Възникна грешка при изпращането на съобщение";
            }

            return RedirectToAction(nameof(Index), new
            {
                receiverId = model.ReceiverId
            });
        }
    }
}
