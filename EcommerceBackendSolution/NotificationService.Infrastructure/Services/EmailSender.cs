using MimeKit;
using NotificationService.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Infrastructure.Services
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("App", "app@example.com"));
            message.To.Add(new MailboxAddress("User", to));
            message.Subject = subject;
            message.Body = new TextPart("plain") { Text = body };

            using var client = new SmtpClient();
            await client.ConnectAsync("smtp.example.com", 587, false);
            await client.AuthenticateAsync("username", "password");
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}
