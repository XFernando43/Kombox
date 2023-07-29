using Microsoft.AspNetCore.Identity.UI.Services;

namespace Kombox.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Here comes the logic from the sender email for confirmation of a account but now is not implemented
            return Task.CompletedTask;
        }
    }
}
