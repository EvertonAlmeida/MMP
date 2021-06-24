using System.Collections.Generic;
using MMP.Domain.Notifications;

namespace MMP.Domain.Interfaces
{
    public interface INotifier
    {
        bool IsThereAnyNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}