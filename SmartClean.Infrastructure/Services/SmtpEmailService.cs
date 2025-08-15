using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SmartClean.Core.Interfaces;
using System.Threading.Tasks;

namespace SmartClean.Infrastructure.Services
{
    public class SmtpEmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;
        private readonly ILogger<SmtpEmailService> _logger;

        public SmtpEmailService(IOptions<EmailSettings> emailSettings, ILogger<SmtpEmailService> logger)
        {
            _emailSettings = emailSettings.Value;
            _logger = logger;
        }

        public Task SendEmailAsync(string to, string subject, string body)
        { 
            _logger.LogInformation($"--- Sending Email ---");
            _logger.LogInformation($"To: {to}");
            _logger.LogInformation($"Subject: {subject}");
            _logger.LogInformation($"Body: {body}");
            _logger.LogInformation("--- Email Sent (Logged) ---");

            // In a real application, you would use an SmtpClient here to send the email.
            // Example:
            // var client = new SmtpClient(_emailSettings.MailServer, _emailSettings.MailPort);
            // client.Credentials = new NetworkCredential(_emailSettings.UserName, _emailSettings.Password);
            // client.EnableSsl = true;
            // await client.SendMailAsync(mailMessage);

            return Task.CompletedTask;
        }
    }
}
