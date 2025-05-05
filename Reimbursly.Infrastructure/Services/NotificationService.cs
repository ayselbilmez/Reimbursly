using Microsoft.Extensions.Logging;
using Reimbursly.Application.Interfaces;

namespace Reimbursly.Infrastructure.Services;

public class NotificationService : INotificationService
{
    private readonly ILogger<NotificationService> _logger;

    public NotificationService(ILogger<NotificationService> logger)
    {
        _logger = logger;
    }

    public Task SendAsync(string toUserEmail, string message)
    {
        _logger.LogInformation($"📩 Notification sent to {toUserEmail}: {message}");
        return Task.CompletedTask;
    }
}
