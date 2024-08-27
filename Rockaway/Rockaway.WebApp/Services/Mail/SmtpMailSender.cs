using MimeKit;
using Rockaway.WebApp.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Rockaway.WebApp.Services.Mail;

public class SmtpMailSender(
	IBackgroundTaskQueue queue, IMailBodyRenderer renderer, ISmtpRelay smtpRelay) : IMailSender {

	private readonly MailboxAddress mailFrom = new("Rockaway Tickets", "tickets@rockaway.dev");

	public MimeMessage BuildOrderConfirmationMail(TicketOrderMailData data) {
		var message = new MimeMessage();
		message.Subject = $"Your tickets to {data.Artist.Name} at {data.VenueName}";
		message.From.Add(mailFrom);
		message.To.Add(new MailboxAddress(data.CustomerName, data.CustomerEmail));
		var bb = new BodyBuilder {
			HtmlBody = renderer.RenderOrderConfirmationHtml(data),
			TextBody = renderer.RenderOrderConfirmationText(data)
		};
		message.Body = bb.ToMessageBody();
		return message;
	}

	public async Task<string> ActuallySendOrderConfirmationAsync(TicketOrderMailData data) {
		var message = BuildOrderConfirmationMail(data);
		await Task.Delay(TimeSpan.FromSeconds(10));
		return await smtpRelay.SendMailAsync(message);
	}

	public async Task SendOrderConfirmationAsync(TicketOrderMailData data)
		=> await queue.QueueBackgroundWorkItemAsync(async () => await ActuallySendOrderConfirmationAsync(data));
}