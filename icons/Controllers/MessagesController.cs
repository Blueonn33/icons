using icons.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace icons.Controllers
{
    public class MessagesController(IMessageService _messageService) : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
