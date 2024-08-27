namespace Rockaway.WebApp.Services.Mail;

public interface IBackgroundTaskQueue {
	ValueTask QueueBackgroundWorkItemAsync(Func<ValueTask> workItem);
	ValueTask<Func<ValueTask>> DequeueAsync(CancellationToken token);
}
