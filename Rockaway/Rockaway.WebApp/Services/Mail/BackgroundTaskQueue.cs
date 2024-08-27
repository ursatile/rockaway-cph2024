using System.Threading.Channels;

namespace Rockaway.WebApp.Services.Mail;

public class BackgroundTaskQueue : IBackgroundTaskQueue {
	private readonly Channel<Func<ValueTask>> queue;

	public BackgroundTaskQueue(int capacity = 100) {
		var options = new BoundedChannelOptions(capacity) { FullMode = BoundedChannelFullMode.Wait };
		queue = Channel.CreateBounded<Func<ValueTask>>(options);
	}

	public async ValueTask QueueBackgroundWorkItemAsync(Func<ValueTask> workItem)
		=> await queue.Writer.WriteAsync(workItem);

	public async ValueTask<Func<ValueTask>> DequeueAsync(CancellationToken token)
		=> await queue.Reader.ReadAsync(token);
}
