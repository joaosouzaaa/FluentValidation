using FluentValidation.API.Settings.NotificationSettings;

namespace FluentValidation.API.Interfaces.Settings;

public interface INotificationHandler
{
    List<Notification> GetNotifications();
    bool HasNotification();
    bool AddNotification(Notification notification);
    bool AddNotification(string key, string message);
}
