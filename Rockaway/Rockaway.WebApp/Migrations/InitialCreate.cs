using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Rockaway.WebApp.Migrations {
	/// <inheritdoc />
	public partial class InitialCreate : Migration {
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder) {
			migrationBuilder.CreateTable(
				name: "Artist",
				columns: table => new {
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
					Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
					Slug = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
				},
				constraints: table => {
					table.PrimaryKey("PK_Artist", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "AspNetRoles",
				columns: table => new {
					Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
					Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table => {
					table.PrimaryKey("PK_AspNetRoles", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "AspNetUsers",
				columns: table => new {
					Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
					UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
					PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
					SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
					ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
					PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
					PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
					TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
					LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
					LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
					AccessFailedCount = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table => {
					table.PrimaryKey("PK_AspNetUsers", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Venue",
				columns: table => new {
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
					Slug = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
					Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
					City = table.Column<string>(type: "nvarchar(max)", nullable: false),
					CultureName = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: false),
					PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
					WebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table => {
					table.PrimaryKey("PK_Venue", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "AspNetRoleClaims",
				columns: table => new {
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
					ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
					ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table => {
					table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
					table.ForeignKey(
						name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
						column: x => x.RoleId,
						principalTable: "AspNetRoles",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AspNetUserClaims",
				columns: table => new {
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
					ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
					ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table => {
					table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
					table.ForeignKey(
						name: "FK_AspNetUserClaims_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AspNetUserLogins",
				columns: table => new {
					LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
					ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
					ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
					UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
				},
				constraints: table => {
					table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
					table.ForeignKey(
						name: "FK_AspNetUserLogins_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AspNetUserRoles",
				columns: table => new {
					UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
					RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
				},
				constraints: table => {
					table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
					table.ForeignKey(
						name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
						column: x => x.RoleId,
						principalTable: "AspNetRoles",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_AspNetUserRoles_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AspNetUserTokens",
				columns: table => new {
					UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
					LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
					Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
					Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table => {
					table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
					table.ForeignKey(
						name: "FK_AspNetUserTokens_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Show",
				columns: table => new {
					Date = table.Column<DateOnly>(type: "date", nullable: false),
					VenueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					HeadlineArtistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
				},
				constraints: table => {
					table.PrimaryKey("PK_Show", x => new { x.VenueId, x.Date });
					table.ForeignKey(
						name: "FK_Show_Artist_HeadlineArtistId",
						column: x => x.HeadlineArtistId,
						principalTable: "Artist",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Show_Venue_VenueId",
						column: x => x.VenueId,
						principalTable: "Venue",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "SupportSlot",
				columns: table => new {
					SlotNumber = table.Column<int>(type: "int", nullable: false),
					ShowVenueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					ShowDate = table.Column<DateOnly>(type: "date", nullable: false),
					ArtistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
				},
				constraints: table => {
					table.PrimaryKey("PK_SupportSlot", x => new { x.ShowVenueId, x.ShowDate, x.SlotNumber });
					table.ForeignKey(
						name: "FK_SupportSlot_Artist_ArtistId",
						column: x => x.ArtistId,
						principalTable: "Artist",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_SupportSlot_Show_ShowVenueId_ShowDate",
						columns: x => new { x.ShowVenueId, x.ShowDate },
						principalTable: "Show",
						principalColumns: new[] { "VenueId", "Date" },
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "TicketOrder",
				columns: table => new {
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					ShowVenueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					ShowDate = table.Column<DateOnly>(type: "date", nullable: false),
					CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
					CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
					CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
					CompletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
				},
				constraints: table => {
					table.PrimaryKey("PK_TicketOrder", x => x.Id);
					table.ForeignKey(
						name: "FK_TicketOrder_Show_ShowVenueId_ShowDate",
						columns: x => new { x.ShowVenueId, x.ShowDate },
						principalTable: "Show",
						principalColumns: new[] { "VenueId", "Date" },
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "TicketType",
				columns: table => new {
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					ShowVenueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					ShowDate = table.Column<DateOnly>(type: "date", nullable: false),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Price = table.Column<decimal>(type: "money", nullable: false),
					Limit = table.Column<int>(type: "int", nullable: true)
				},
				constraints: table => {
					table.PrimaryKey("PK_TicketType", x => x.Id);
					table.ForeignKey(
						name: "FK_TicketType_Show_ShowVenueId_ShowDate",
						columns: x => new { x.ShowVenueId, x.ShowDate },
						principalTable: "Show",
						principalColumns: new[] { "VenueId", "Date" },
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "TicketOrderItem",
				columns: table => new {
					TicketOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					TicketTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					Quantity = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table => {
					table.PrimaryKey("PK_TicketOrderItem", x => new { x.TicketOrderId, x.TicketTypeId });
					table.ForeignKey(
						name: "FK_TicketOrderItem_TicketOrder_TicketOrderId",
						column: x => x.TicketOrderId,
						principalTable: "TicketOrder",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_TicketOrderItem_TicketType_TicketTypeId",
						column: x => x.TicketTypeId,
						principalTable: "TicketType",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.InsertData(
				table: "Artist",
				columns: new[] { "Id", "Description", "Name", "Slug" },
				values: new object[,]
				{
					{ new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa10"), "Enigmatic and mysterious, Java’s Crypt are shrouded in secrecy, their enigmatic melodies and cryptic lyrics take listeners on a thrilling journey through the unknown realms of music.", "Java’s Crypt", "javas-crypt" },
					{ new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa11"), "An electrifying whirlwind, Killer Bite unleash a torrent of energy through their performances, captivating audiences with their explosive riffs and heart-pounding rhythms.", "Killer Bite", "killer-bite" },
					{ new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa12"), "Pioneers of progressive rock, Lambda of God is an innovative band that pushes the boundaries of musical expression, combining intricate compositions and thought-provoking lyrics that resonate deeply with their dedicated fanbase.", "Lambda of God", "lambda-of-god" },
					{ new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa13"), "Quirky and witty, the Null Terminated String Band is a rock group that weaves clever humor and geeky references into their catchy tunes, bringing a smile to the faces of both tech enthusiasts and music lovers alike.", "Null Terminated String Band", "null-terminated-string-band" },
					{ new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa14"), "A charismatic ensemble, Mott the Tuple blends vintage charm with a modern edge, creating a unique sound that captivates audiences and takes them on a nostalgic journey through time.", "Mott the Tuple", "mott-the-tuple" },
					{ new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa15"), "Overflowing with passion and intensity, Överflow is a rock band that immerses listeners in a tsunami of sound, exploring emotions through powerful melodies and soul-stirring performances.", "Överflow", "overflow" },
					{ new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa16"), "Philosophers of rock, Pascal’s Wager delves into existential themes with their intellectually charged songs, prompting listeners to ponder the profound questions of life and purpose.", "Pascal’s Wager", "pascals-wager" },
					{ new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa17"), "Futuristic and avant-garde, Qüantum Gäte defy conventions, using experimental sounds and innovative compositions to transport listeners to other dimensions of music.", "Qüantum Gäte", "quantum-gate" },
					{ new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa18"), "High-energy and rebellious, Run CMD is a rock band that merges technology themes with headbanging-worthy tunes, igniting the stage with their electrifying presence and infectious enthusiasm.", "Run CMD", "run-cmd" },
					{ new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa19"), "Mischievous and bold, <Script>Kiddies subvert expectations with clever musical pranks, weaving clever wordplay and tongue-in-cheek humor into their audacious performances.", "<Script>Kiddies", "script-kiddies" },
					{ new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa20"), "Masters of atmosphere, Terrorform’s dark and atmospheric rock ensembles conjure hauntingly beautiful soundscapes that captivate the senses and evoke a deep emotional response.", "Terrorform", "terrorform" },
					{ new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa21"), "ᵾnɨȼøđɇɍ harmonize complex equations and melodies, weaving a symphony of logic and emotion in their unique and captivating music.", "ᵾnɨȼøđɇɍ", "unicoder" },
					{ new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa22"), "Bridging reality and virtuality, Virtual Machine is a surreal rock group that blurs the lines between the tangible and the digital, creating mind-bending performances that leave audiences questioning the nature of existence.", "Virtual Machine", "virtual-machine" },
					{ new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa23"), "Technologically savvy and creatively ambitious, Webmaster of Puppets is a web-inspired rock band, crafting narratives of digital dominance and manipulation with their inventive music.", "Webmaster of Puppets", "webmaster-of-puppets" },
					{ new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa24"), "Mesmerizing and genre-defying, XSLTE is an enchanting rock ensemble that fuses electronic and rock elements, creating a spellbinding sound that enthralls listeners and transports them to MakeArtist sonic landscapes.", "XSLTE", "xslte" },
					{ new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa25"), "Youthful and exuberant, YAMB spreads positivity and infectious energy through their music, connecting with fans through their youthful spirit and heartwarming performances.", "YAMB", "yamb" },
					{ new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa26"), "Innovative and exploratory, Zero Based Index starts from scratch, building powerful narratives through their dynamic sound, leaving audiences inspired and moved by their expressive and daring music.", "Zero Based Index", "zero-based-index" },
					{ new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa27"), "Inspired by their Australian namesakes, Ærbårn are Scandinavia's #1 party rock band. Thundering drums, huge guitar riffs and enough energy to light up the Arctic Circle, their shows have had amazing reviews all over the world", "Ærbårn", "aerbaarn" },
					{ new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa28"), "dot-dot-dot to their friends (and fans), ... are a Canadian drone jazz combo formed in Vancouver in 1998, known for their thunderous horn section and innovative visuals.", "...", "dot-dot-dot" },
					{ new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa29"), "Known as the \"Silver Mountain Strings\" if you're into the whole brevity thing, Kentucky's answer to the Leningrad Cowboys has gone from strength to strength, from the Superbowl half time show to their sold-out Vegas residency in 2023.", "The Silver Mountain String Band featuring Timber J. MacCorkindale and the Hill Valley Hornswogglers", "silver-mountain-string-band" },
					{ new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa1"), "Alter Column are South Africa's hottest math rock export. Founded in Cape Town in 2021, their debut album \"Drop Table Mountain\" was nominated for four Grammy awards.", "Alter Column", "alter-column" },
					{ new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa2"), "Speed metal pioneers from San Francisco, <Body>Bag helped define the “web rock” sound in the early 2020s.", "<Body>Bag", "body-bag" },
					{ new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa3"), "Hailing from a distant future, Coda is a time-traveling rock band known for their mind-bending melodies that transport audiences through different eras, merging past and future into a harmonious blend of sound.", "Coda", "coda" },
					{ new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa4"), "Rising from the ashes of adversity, Dev Leppard is a fiercely talented rock band that overcame obstacles with sheer determination, captivating fans worldwide with their electrifying performances and showcasing a bond that empowers their music.", "Dev Leppard", "dev-leppard" },
					{ new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa5"), "Merging the realms of art and emotion, Электроника is an introspective rock group, infusing their hauntingly beautiful lyrics with mesmerizing melodies that delve into the depths of human existence, leaving listeners immersed in profound reflections.", "Электроника", "elektronika" },
					{ new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa6"), "With an otherworldly allure, For Ear Transform is an ethereal rock ensemble, their music transcends reality, leading listeners on a dreamlike journey where celestial harmonies and ethereal instrumentation create a captivating and transformative experience.", "For Ear Transform", "for-ear-transform" },
					{ new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa7"), "Rebel rockers with a cause, Garbage Collectors are raw, raucous and unapologetic, fearlessly tackling social issues and societal norms in their music, energizing crowds with their powerful anthems and unyielding spirit.", "Garbage Collectors", "garbage-collectors" },
					{ new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa8"), "Virtuosos of rhythm and harmony, Haskell’s Angels radiate a divine aura, blending complex melodies and celestial harmonies that resonate deep within the soul.", "Haskell’s Angels", "haskells-angels" },
					{ new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa9"), "A force to be reckoned with, Iron Median are known for their thunderous beats and adrenaline-pumping anthems, electrifying audiences with their commanding stage presence and unstoppable energy.", "Iron Median", "iron-median" }
				});

			migrationBuilder.InsertData(
				table: "AspNetUsers",
				columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
				values: new object[] { "rockaway-sample-admin-user", 0, "a3d73c3e-0041-4d74-8dd1-7ed9110c5648", "admin@rockaway.dev", true, true, null, "ADMIN@ROCKAWAY.DEV", "ADMIN@ROCKAWAY.DEV", "AQAAAAIAAYagAAAAEPwT7fwjOsUd2Mwby22AIGPUW9FxgzpclcuUdyUem/5xldOFhtXjKFC3DSO8pv3OqA==", null, true, "c120cd4a-daed-40bd-a5f1-6517d2bad5c7", false, "admin@rockaway.dev" });

			migrationBuilder.InsertData(
				table: "Venue",
				columns: new[] { "Id", "Address", "City", "CultureName", "Name", "PostalCode", "Slug", "Telephone", "WebsiteUrl" },
				values: new object[,]
				{
					{ new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb1"), "Town Hall Parade", "London", "en-GB", "Electric Brixton", "SW2 1RJ", "electric-brixton", "020 7274 2290", "https://www.electricbrixton.uk.com/" },
					{ new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb2"), "50 Boulevard Voltaire", "Paris", "fr-FR", "Bataclan", "75011", "bataclan-paris", "+33 1 43 14 00 30", "https://www.bataclan.fr/" },
					{ new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb3"), "Columbiadamm 9 - 11", "Berlin", "de-DE", "Columbia Theatre", "10965", "columbia-berlin", "+49 30 69817584", "https://columbia-theater.de/" },
					{ new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb4"), "Liosion 205", "Athens", "el-GR", "Gagarin 205", "104 45", "gagarin-athens", "+45 35 35 50 69", "" },
					{ new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb5"), "Torggata 16", "Oslo", "nn-NO", "John Dee Live Club & Pub", "0181", "john-dee-oslo", "+47 22 20 32 32", "https://www.rockefeller.no/" },
					{ new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb6"), "Stengade 18", "Copenhagen", "da-DK", "Stengade", "2200", "stengade-copenhagen", "+45 35355069", "https://www.stengade.dk" },
					{ new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb7"), "R da Madeira 186", "Porto", "pt-PT", "Barracuda", "4000-433", "barracuda-porto", null, null },
					{ new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb8"), "Sveavägen 90", "Stockholm", "sv-SE", "Pub Anchor", "113 59", "pub-anchor-stockholm", "+46 8 15 20 00", "https://www.instagram.com/pubanchor/?hl=en" },
					{ new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb9"), "323 New Cross Road", "London", "en-GB", "New Cross Inn", "SE14 6AS", "new-cross-inn-london", "+44 20 8469 4382", "https://www.newcrossinn.com/" }
				});

			migrationBuilder.InsertData(
				table: "Show",
				columns: new[] { "Date", "VenueId", "HeadlineArtistId" },
				values: new object[,]
				{
					{ new DateOnly(2024, 8, 29), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb2"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa3") },
					{ new DateOnly(2024, 8, 28), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb3"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa3") },
					{ new DateOnly(2024, 9, 2), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb4"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa3") },
					{ new DateOnly(2024, 8, 31), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb5"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa3") },
					{ new DateOnly(2024, 8, 27), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb7"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa3") },
					{ new DateOnly(2024, 9, 1), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb8"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa3") },
					{ new DateOnly(2024, 8, 30), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb9"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa3") }
				});

			migrationBuilder.InsertData(
				table: "SupportSlot",
				columns: new[] { "ShowDate", "ShowVenueId", "SlotNumber", "ArtistId" },
				values: new object[,]
				{
					{ new DateOnly(2024, 8, 29), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb2"), 1, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa11") },
					{ new DateOnly(2024, 8, 29), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb2"), 2, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa15") },
					{ new DateOnly(2024, 8, 29), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb2"), 3, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa10") },
					{ new DateOnly(2024, 8, 28), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb3"), 1, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa11") },
					{ new DateOnly(2024, 8, 28), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb3"), 2, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa15") },
					{ new DateOnly(2024, 9, 2), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb4"), 1, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa10") },
					{ new DateOnly(2024, 9, 2), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb4"), 2, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa29") },
					{ new DateOnly(2024, 8, 31), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb5"), 1, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa10") },
					{ new DateOnly(2024, 8, 27), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb7"), 1, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa11") },
					{ new DateOnly(2024, 8, 27), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb7"), 2, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa15") },
					{ new DateOnly(2024, 9, 1), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb8"), 1, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa10") },
					{ new DateOnly(2024, 8, 30), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb9"), 1, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa10") }
				});

			migrationBuilder.InsertData(
				table: "TicketOrder",
				columns: new[] { "Id", "CompletedAt", "CreatedAt", "CustomerEmail", "CustomerName", "ShowDate", "ShowVenueId" },
				values: new object[,]
				{
					{ new Guid("560ed55e-c635-4f0e-a433-a23ab6fa7bb6"), new DateTimeOffset(new DateTime(2024, 7, 19, 13, 40, 18, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 7, 19, 13, 4, 18, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "brian@example.com", "Brian Johnson", new DateOnly(2024, 8, 30), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb9") },
					{ new Guid("ac824d10-367f-494c-ad32-f221420c7c3c"), new DateTimeOffset(new DateTime(2024, 7, 16, 9, 37, 16, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 7, 16, 9, 4, 16, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "ace@example.com", "Ace Frehley", new DateOnly(2024, 8, 27), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb7") },
					{ new Guid("f584739d-2ec0-4de8-8de2-140333516b4f"), new DateTimeOffset(new DateTime(2024, 7, 21, 10, 35, 12, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 7, 21, 10, 4, 12, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "joey.tempest@example.com", "Joey Tempest", new DateOnly(2024, 9, 1), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb8") }
				});

			migrationBuilder.InsertData(
				table: "TicketType",
				columns: new[] { "Id", "Limit", "Name", "Price", "ShowDate", "ShowVenueId" },
				values: new object[,]
				{
					{ new Guid("cccccccc-cccc-cccc-cccc-cccccccccc10"), null, "General Admission", 350m, new DateOnly(2024, 8, 31), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb5") },
					{ new Guid("cccccccc-cccc-cccc-cccc-cccccccccc11"), null, "VIP Meet & Greet", 750m, new DateOnly(2024, 8, 31), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb5") },
					{ new Guid("cccccccc-cccc-cccc-cccc-cccccccccc12"), null, "General Admission", 300m, new DateOnly(2024, 9, 1), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb8") },
					{ new Guid("cccccccc-cccc-cccc-cccc-cccccccccc13"), null, "VIP Meet & Greet", 720m, new DateOnly(2024, 9, 1), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb8") },
					{ new Guid("cccccccc-cccc-cccc-cccc-cccccccccc14"), null, "General Admission", 25m, new DateOnly(2024, 9, 2), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb4") },
					{ new Guid("cccccccc-cccc-cccc-cccc-ccccccccccc1"), null, "Upstairs unallocated seating", 25m, new DateOnly(2024, 8, 27), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb7") },
					{ new Guid("cccccccc-cccc-cccc-cccc-ccccccccccc2"), null, "Downstairs standing", 25m, new DateOnly(2024, 8, 27), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb7") },
					{ new Guid("cccccccc-cccc-cccc-cccc-ccccccccccc3"), null, "Cabaret table (4 people)", 120m, new DateOnly(2024, 8, 27), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb7") },
					{ new Guid("cccccccc-cccc-cccc-cccc-ccccccccccc4"), null, "General Admission", 35m, new DateOnly(2024, 8, 28), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb3") },
					{ new Guid("cccccccc-cccc-cccc-cccc-ccccccccccc5"), null, "VIP Meet & Greet", 75m, new DateOnly(2024, 8, 28), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb3") },
					{ new Guid("cccccccc-cccc-cccc-cccc-ccccccccccc6"), null, "General Admission", 35m, new DateOnly(2024, 8, 29), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb2") },
					{ new Guid("cccccccc-cccc-cccc-cccc-ccccccccccc7"), null, "VIP Meet & Greet", 75m, new DateOnly(2024, 8, 29), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb2") },
					{ new Guid("cccccccc-cccc-cccc-cccc-ccccccccccc8"), null, "General Admission", 25m, new DateOnly(2024, 8, 30), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb9") },
					{ new Guid("cccccccc-cccc-cccc-cccc-ccccccccccc9"), null, "VIP Meet & Greet", 55m, new DateOnly(2024, 8, 30), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb9") }
				});

			migrationBuilder.InsertData(
				table: "TicketOrderItem",
				columns: new[] { "TicketOrderId", "TicketTypeId", "Quantity" },
				values: new object[,]
				{
					{ new Guid("560ed55e-c635-4f0e-a433-a23ab6fa7bb6"), new Guid("cccccccc-cccc-cccc-cccc-ccccccccccc8"), 3 },
					{ new Guid("560ed55e-c635-4f0e-a433-a23ab6fa7bb6"), new Guid("cccccccc-cccc-cccc-cccc-ccccccccccc9"), 2 },
					{ new Guid("ac824d10-367f-494c-ad32-f221420c7c3c"), new Guid("cccccccc-cccc-cccc-cccc-ccccccccccc1"), 4 },
					{ new Guid("ac824d10-367f-494c-ad32-f221420c7c3c"), new Guid("cccccccc-cccc-cccc-cccc-ccccccccccc2"), 5 },
					{ new Guid("ac824d10-367f-494c-ad32-f221420c7c3c"), new Guid("cccccccc-cccc-cccc-cccc-ccccccccccc3"), 5 },
					{ new Guid("f584739d-2ec0-4de8-8de2-140333516b4f"), new Guid("cccccccc-cccc-cccc-cccc-cccccccccc12"), 3 },
					{ new Guid("f584739d-2ec0-4de8-8de2-140333516b4f"), new Guid("cccccccc-cccc-cccc-cccc-cccccccccc13"), 2 }
				});

			migrationBuilder.CreateIndex(
				name: "IX_Artist_Slug",
				table: "Artist",
				column: "Slug",
				unique: true);

			migrationBuilder.CreateIndex(
				name: "IX_AspNetRoleClaims_RoleId",
				table: "AspNetRoleClaims",
				column: "RoleId");

			migrationBuilder.CreateIndex(
				name: "RoleNameIndex",
				table: "AspNetRoles",
				column: "NormalizedName",
				unique: true,
				filter: "[NormalizedName] IS NOT NULL");

			migrationBuilder.CreateIndex(
				name: "IX_AspNetUserClaims_UserId",
				table: "AspNetUserClaims",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_AspNetUserLogins_UserId",
				table: "AspNetUserLogins",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_AspNetUserRoles_RoleId",
				table: "AspNetUserRoles",
				column: "RoleId");

			migrationBuilder.CreateIndex(
				name: "EmailIndex",
				table: "AspNetUsers",
				column: "NormalizedEmail");

			migrationBuilder.CreateIndex(
				name: "UserNameIndex",
				table: "AspNetUsers",
				column: "NormalizedUserName",
				unique: true,
				filter: "[NormalizedUserName] IS NOT NULL");

			migrationBuilder.CreateIndex(
				name: "IX_Show_HeadlineArtistId",
				table: "Show",
				column: "HeadlineArtistId");

			migrationBuilder.CreateIndex(
				name: "IX_SupportSlot_ArtistId",
				table: "SupportSlot",
				column: "ArtistId");

			migrationBuilder.CreateIndex(
				name: "IX_TicketOrder_ShowVenueId_ShowDate",
				table: "TicketOrder",
				columns: new[] { "ShowVenueId", "ShowDate" });

			migrationBuilder.CreateIndex(
				name: "IX_TicketOrderItem_TicketTypeId",
				table: "TicketOrderItem",
				column: "TicketTypeId");

			migrationBuilder.CreateIndex(
				name: "IX_TicketType_ShowVenueId_ShowDate",
				table: "TicketType",
				columns: new[] { "ShowVenueId", "ShowDate" });

			migrationBuilder.CreateIndex(
				name: "IX_Venue_Slug",
				table: "Venue",
				column: "Slug",
				unique: true);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder) {
			migrationBuilder.DropTable(
				name: "AspNetRoleClaims");

			migrationBuilder.DropTable(
				name: "AspNetUserClaims");

			migrationBuilder.DropTable(
				name: "AspNetUserLogins");

			migrationBuilder.DropTable(
				name: "AspNetUserRoles");

			migrationBuilder.DropTable(
				name: "AspNetUserTokens");

			migrationBuilder.DropTable(
				name: "SupportSlot");

			migrationBuilder.DropTable(
				name: "TicketOrderItem");

			migrationBuilder.DropTable(
				name: "AspNetRoles");

			migrationBuilder.DropTable(
				name: "AspNetUsers");

			migrationBuilder.DropTable(
				name: "TicketOrder");

			migrationBuilder.DropTable(
				name: "TicketType");

			migrationBuilder.DropTable(
				name: "Show");

			migrationBuilder.DropTable(
				name: "Artist");

			migrationBuilder.DropTable(
				name: "Venue");
		}
	}
}
