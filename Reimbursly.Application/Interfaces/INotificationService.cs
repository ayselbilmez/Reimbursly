namespace Reimbursly.Application.Interfaces;

public interface INotificationService
{
    Task SendAsync(string toUserEmail, string message);
}
