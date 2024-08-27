// Rockaway.WebApp/Services/Mail/IMailTemplateProvider.cs
using Mjml.Net;
using RazorEngineCore;
using Rockaway.WebApp.Models;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Rockaway.WebApp.Services.Mail;

public interface IMailTemplateProvider {
	string OrderConfirmationMjml { get; }
	string OrderConfirmationText { get; }
}

public class ResourceMailTemplateProvider : IMailTemplateProvider {

	public string OrderConfirmationMjml => ReadEmbeddedResource("OrderConfirmation.mjml");
	public string OrderConfirmationText => ReadEmbeddedResource("OrderConfirmation.txt");

	private static string ReadEmbeddedResource(string resourceFileName) {
		var assembly = Assembly.GetEntryAssembly()!;
		var qualifiedName = $"{assembly.GetName().Name}.Templates.Mail.{resourceFileName}";
		var stream = assembly.GetManifestResourceStream(qualifiedName)!;
		return new StreamReader(stream).ReadToEnd();
	}

}

public class DebugMailTemplateProvider : IMailTemplateProvider {
	private string ReadFile(string filename, [CallerFilePath] string callerFilePath = "") {
		var path = Path.Combine(callerFilePath, "..", "..", "..", "Templates", "Mail", filename);
		return File.ReadAllText(path);
	}
	public string OrderConfirmationMjml => ReadFile("OrderConfirmation.mjml");
	public string OrderConfirmationText => ReadFile("OrderConfirmation.txt");
}

public interface IMailBodyRenderer {
	string RenderOrderConfirmationHtml(TicketOrderViewData data);
	string RenderOrderConfirmationText(TicketOrderViewData data);
}

public class MailBodyRenderer : IMailBodyRenderer {
	private readonly IRazorEngine razor;
	private readonly IMjmlRenderer mjml;
	private readonly IMailTemplateProvider templates;

	private IRazorEngineCompiledTemplate html;
	private IRazorEngineCompiledTemplate text;

	public MailBodyRenderer(IMailTemplateProvider templates, IMjmlRenderer mjml, IRazorEngine razor) {
		this.templates = templates;
		this.mjml = mjml;
		this.razor = razor;
		var htmlTemplateSource = mjml.Render(templates.OrderConfirmationMjml).Html;
		html = razor.Compile(EscapeCssRulesSoRazorDoesNotChokeOnThem(htmlTemplateSource));
		text = razor.Compile(templates.OrderConfirmationText);

	}

	public string RenderOrderConfirmationHtml(TicketOrderViewData data) {
#if DEBUG // only recompile the template on every request if we're in DEBUG mode.
		var htmlTemplateSource = mjml.Render(templates.OrderConfirmationMjml).Html;
		html = razor.Compile(EscapeCssRulesSoRazorDoesNotChokeOnThem(htmlTemplateSource));
#endif
		return html.Run(data);
	}

	public string RenderOrderConfirmationText(TicketOrderViewData data) {
#if DEBUG
		text = razor.Compile(templates.OrderConfirmationText);
#endif
		return text.Run(data);
	}

	private string EscapeCssRulesSoRazorDoesNotChokeOnThem(string razorSource) =>
		cssRules.Aggregate(razorSource, (haystack, needle) => haystack.Replace($"{needle}", $"@{needle}"));

	private static readonly string[] cssRules = @"
		@bottom-center @bottom-left @bottom-left-corner @bottom-right 
		@bottom-right-corner @charset @counter-style @document @font-face 
		@font-feature-values @import @left-bottom @left-middle @left-top 
		@keyframes @media @namespace @page @right-bottom @right-middle 
		@right-top @supports @top-center @top-left @top-left-corner 
		@top-right @top-right-corner".Split(' ', StringSplitOptions.RemoveEmptyEntries);
}
