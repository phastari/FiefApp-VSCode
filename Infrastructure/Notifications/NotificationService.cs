using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Models;

namespace Infrastructure.Notifications
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(MessageDto message)
        {
            return Task.CompletedTask;
        }
    }
}