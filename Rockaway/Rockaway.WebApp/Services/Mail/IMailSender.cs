using Rockaway.WebApp.Models;

namespace Rockaway.WebApp.Services.Mail;

public interface IMailSender {
	Task SendOrderConfirmationAsync(TicketOrderMailData data);
}

// Rockaway.WebApp/Services/Mail/SmtpMailSender.cs