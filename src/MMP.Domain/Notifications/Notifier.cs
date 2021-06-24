using System.Collections.Generic;
using System.Linq;
using MMP.Domain.Interfaces;

namespace MMP.Domain.Notifications
{
    public class Notifier : INotifier
    {
        private List<Notification> _notifications;
        public Notifier()
        {
            _notifications = new List<Notification>();
        }

        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }

        public bool IsThereAnyNotification()
        {
            return _notifications.Any();
        }
    }
}