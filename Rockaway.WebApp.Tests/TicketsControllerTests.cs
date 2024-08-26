using Microsoft.AspNetCore.Mvc;
using NodaTime;
using NodaTime.Testing;
using Rockaway.WebApp.Controllers;
using Rockaway.WebApp.Data.Sample;
using Rockaway.WebApp.Models;
using Shouldly;

namespace Rockaway.WebApp.Tests;

public class TicketsControllerTests {
	[Fact]
	public async Task Show_Returns_View() {
		var db = TestDatabase.Create();
		var clock = new FakeClock(Instant.FromUtc(2024,8,28,10,30));
		var c = new TicketsController(db, clock);
		var testShow = SampleData.Shows.Coda_Barracuda_20240517;
		var result = await c.Show(testShow.Venue.Slug, testShow.Date) as ViewResult;
		Assert.NotNull(result);
	}

	[Fact]
	public async Task Show_Returns_Correct_Artist() {
		var db = TestDatabase.Create();
		var clock = new FakeClock(Instant.FromUtc(2024, 8, 28, 10, 30));
		var c = new TicketsController(db, clock);
		var testShow = SampleData.Shows.Coda_Barracuda_20240517;
		var result = await c.Show(testShow.Venue.Slug, testShow.Date) as ViewResult;
		var model = result.Model as ShowViewData;
		model.ShouldNotBeNull();
		model.HeadlineArtistName.ShouldBe(SampleData.Artists.Coda.Name);
	}
}