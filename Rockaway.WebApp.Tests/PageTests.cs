using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Rockaway.WebApp.Tests {
	public class PageTests {
		[Fact]
		public async Task Index_Page_Returns_Success() {
			await using var factory = new WebApplicationFactory<Program>();
			using var client = factory.CreateClient();
			using var response = await client.GetAsync("/");
			response.EnsureSuccessStatusCode();
		}
	}
}
