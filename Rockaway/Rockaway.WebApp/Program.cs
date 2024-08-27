using Microsoft.AspNetCore.Identity;
using Microsoft.Data.Sqlite;
using Mjml.Net;
using RazorEngineCore;
using Rockaway.RazorComponents;
using Rockaway.WebApp.Data;
using Rockaway.WebApp.Hosting;
using Rockaway.WebApp.Services;
using Rockaway.WebApp.Services.Mail;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages(options => options.Conventions.AuthorizeAreaFolder("admin", "/"));
builder.Services.AddControllersWithViews(options => {
	options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
});
builder.Services.AddSingleton<IClock>(SystemClock.Instance);

builder.Services.AddSingleton<IStatusReporter>(new StatusReporter());


var logger = CreateAdHocLogger<Program>();
logger.LogInformation("Rockaway running in {environment} environment", builder.Environment.EnvironmentName);

if (builder.Environment.UseSqlite()) {
	logger.LogInformation("Using Sqlite database");
	var sqliteConnection = new SqliteConnection("Data Source=:memory:");
	sqliteConnection.Open();
	builder.Services.AddDbContext<RockawayDbContext>(options => options.UseSqlite(sqliteConnection));
} else {
	logger.LogInformation("Using SQL Server database");
	var connectionString = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
	builder.Services.AddDbContext<RockawayDbContext>(options => options.UseSqlServer(connectionString));
}

builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<RockawayDbContext>();
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

#if DEBUG && !NCRUNCH
builder.Services.AddSassCompiler();
#endif

builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents()
	.AddInteractiveWebAssemblyComponents();


#if DEBUG
builder.Services.AddSingleton<IMailTemplateProvider>(new DebugMailTemplateProvider());
#else
builder.Services.AddSingleton<IMailTemplateProvider>(new ResourceMailTemplateProvider());
#endif
builder.Services.AddSingleton<IMailBodyRenderer, MailBodyRenderer>();
builder.Services.AddSingleton<IRazorEngine, RazorEngine>();
builder.Services.AddSingleton<IMjmlRenderer, MjmlRenderer>();

builder.Services.AddSingleton<IMailSender, SmtpMailSender>();
var smtpSettings = new SmtpSettings();
builder.Configuration.Bind("Smtp", smtpSettings);
logger.LogInformation($"Using {smtpSettings.Host} as SMTP relay server");
builder.Services.AddSingleton(smtpSettings);
builder.Services.AddSingleton<ISmtpRelay, SmtpRelay>();

if (! builder.Environment.IsDevelopment()) builder.WebHost.UseStaticWebAssets();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsProduction()) {
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}



using var scope = app.Services.CreateScope();
using var db = scope.ServiceProvider.GetService<RockawayDbContext>()!;

if (app.Environment.UseSqlite()) {
	db.Database.EnsureCreated();
} else if (Boolean.TryParse(app.Configuration["apply-migrations"], out var applyMigrations) && applyMigrations) {
	logger.LogInformation("apply-migrations=true was specified. Applying EF migrations and then exiting.");
	db.Database.Migrate();
	logger.LogInformation("EF database migrations applied successfully.");
	Environment.Exit(0);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapGet("/status", (IStatusReporter reporter) => reporter.GetStatus());

app.MapAreaControllerRoute(
	name: "admin",
	areaName: "Admin",
	pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
).RequireAuthorization();
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
app.MapControllers();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode()
	.AddInteractiveWebAssemblyRenderMode();

app.Run();
ILogger<T> CreateAdHocLogger<T>() => LoggerFactory.Create(lb => lb.AddConsole()).CreateLogger<T>();
