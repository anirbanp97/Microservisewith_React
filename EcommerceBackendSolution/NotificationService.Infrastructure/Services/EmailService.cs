using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Infrastructure.Services
{
    public class EmailService
    {
        public async Task SendEmailAsync(string to, string subject, string body)
        {
            Console.WriteLine($"📤 Sending Email to {to}: {subject} - {body}");
            await Task.CompletedTask;
        }
    }
}
