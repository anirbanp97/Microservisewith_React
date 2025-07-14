using NotificationService.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Infrastructure.Services
{
    public class SmsSender : ISmsSender
    {
        public Task SendSmsAsync(string phoneNumber, string message)
        {
            // Placeholder for actual SMS logic
            Console.WriteLine($"Sending SMS to {phoneNumber}: {message}");
            return Task.CompletedTask;
        }
    }
}
