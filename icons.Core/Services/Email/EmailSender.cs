using Microsoft.AspNetCore.Identity.UI.Services;

namespace icons.Core.Services.Email
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            Console.WriteLine($"Email to {email}: {subject}");
            return Task.CompletedTask;
        }
    }
}
