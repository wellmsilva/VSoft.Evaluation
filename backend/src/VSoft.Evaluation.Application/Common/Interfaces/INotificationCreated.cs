namespace VSoft.Evaluation.Application.Common.Interfaces;

public interface INotificationCreated
{
    DateTime NotificationDate { get; }
    string NotificationMessage { get; }
    object NotificationContent { get; }
    NotificationType NotificationType { get; }
}
