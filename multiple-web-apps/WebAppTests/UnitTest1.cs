using Microsoft.AspNetCore.Mvc.Testing;

namespace WebAppTests;

using wa1 = WebApp1;
using wa2 = WebApp2;

public class UnitTest1
{
	[Fact]
	public async Task Test1()
	{
		global::MyClass
		await using var factory1 = new WebApplicationFactory<WebApp1::Program>();
		await using var factory2 = new WebApplicationFactory<WebApp2::Program>();
		using var client1 = factory1.CreateClient();
		using var client2 = factory2.CreateClient();
		using var response1 = await client1.GetAsync("/");
		using var response2 = await client2.GetAsync("/");
		var html1 = response1.Content.ReadAsStringAsync();
		var html2 = response2.Content.ReadAsStringAsync();
		Assert.Equal(html1, html2);
	}
}