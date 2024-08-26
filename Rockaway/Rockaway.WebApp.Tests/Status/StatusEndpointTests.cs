using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Rockaway.WebApp.Services;
using Shouldly;

namespace Rockaway.WebApp.Tests.Status {
	public class StatusEndpointTests {

		private static readonly ServerStatus testStatus = new() {
			Assembly = "TEST_ASSEMBLY",
			Modified = new DateTimeOffset(2021, 2, 3, 4, 5, 6, TimeSpan.Zero).ToString("O"),
			Hostname = "TEST_HOST",
			DateTime = new DateTimeOffset(2022, 3, 4, 5, 6, 7, TimeSpan.Zero).ToString("O")
		};

		private class TestStatusReporter : IStatusReporter {
			public ServerStatus GetStatus() => testStatus;
		}

		private static JsonSerializerOptions options
			= new JsonSerializerOptions(JsonSerializerDefaults.Web);

		[Fact]
		public async Task Status_Endpoint_Returns_Hostname() {
			var factory = new WebApplicationFactory<Program>()
				.WithWebHostBuilder(builder => builder.ConfigureServices(services => {
					services.AddSingleton<IStatusReporter>(new TestStatusReporter());
				})); using var client = factory.CreateClient();
			using var response = await client.GetAsync("/status");
			var json = await response.Content.ReadAsStringAsync();
			var status = JsonSerializer.Deserialize<ServerStatus>(json, options);
			Assert.NotNull(status);
			status.Hostname.ShouldBe(testStatus.Hostname);
			status.Assembly.ShouldBe(testStatus.Assembly);
		}
	}
}
