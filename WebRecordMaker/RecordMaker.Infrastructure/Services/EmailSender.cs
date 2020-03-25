using System;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace RecordMaker.Infrastructure.Services
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmail(string body)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("test@example.com", "Example User");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("patryk.mauer@gmail.com", "Example User");
            var plainTextContent = body;
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}