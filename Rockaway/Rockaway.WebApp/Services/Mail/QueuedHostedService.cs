namespace Rockaway.WebApp.Services.Mail;

public class QueuedHostedService(IBackgroundTaskQueue taskQueue, ILogger<QueuedHostedService> logger) : BackgroundService {
	public IBackgroundTaskQueue TaskQueue { get; } = taskQueue;

	protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
		await BackgroundProcessing(stoppingToken);
	}

	private async Task BackgroundProcessing(CancellationToken token) {
		while (!token.IsCancellationRequested) {
			var workItem = await TaskQueue.DequeueAsync(token);
			try {
				await workItem();
			}
			catch (Exception ex) {
				logger.LogError(ex, "Error occurred executing {WorkItem}.", nameof(workItem));
			}
		}
	}

	public override async Task StopAsync(CancellationToken stoppingToken) {
		logger.LogInformation("Queued Hosted Service is stopping.");
		await base.StopAsync(stoppingToken);
	}
}
