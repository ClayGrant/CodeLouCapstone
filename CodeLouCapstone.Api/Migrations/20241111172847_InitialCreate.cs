using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodeLouCapstone.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    CardId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CardName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.CardId);
                });

            migrationBuilder.CreateTable(
                name: "Decks",
                columns: table => new
                {
                    DeckId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cards = table.Column<string>(type: "TEXT", nullable: false),
                    DeckName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decks", x => x.DeckId);
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "CardId", "CardName" },
                values: new object[,]
                {
                    { 1, "Plains" },
                    { 2, "Island" },
                    { 3, "Swamp" },
                    { 4, "Mountain" },
                    { 5, "Forest" },
                    { 6, "Abandoned Campground" },
                    { 7, "Abhorrent Oculus" },
                    { 8, "Abrade" },
                    { 9, "Abraded Bluffs" },
                    { 10, "Absolving Lammasu" },
                    { 11, "Abuelo, Ancestral Echo" },
                    { 12, "Abuelo's Awakening" },
                    { 13, "Abyssal Gorestalker" },
                    { 14, "Academy Loremaster" },
                    { 15, "Academy Wall" },
                    { 16, "Aclazotz, Deepest Betrayal" },
                    { 17, "Acolyte of Aclazotz" },
                    { 18, "Acrobatic Cheerleader" },
                    { 19, "Acrobatic Leap" },
                    { 20, "Adaptive Gemguard" },
                    { 21, "Adaptive Sporesinger" },
                    { 22, "Adakar Wastes" },
                    { 23, "Aerial Boost" },
                    { 24, "Aeronaut Cavalry" },
                    { 25, "Aeronaut's Wings" },
                    { 26, "Aetherblade Agent" },
                    { 27, "Aether Channeler" },
                    { 28, "Aftermath Analyst" },
                    { 29, "Against All Odds" },
                    { 30, "Agate Assault" },
                    { 31, "Agate-Blade Assassin" },
                    { 32, "Agatha of the Vile Cauldron" },
                    { 33, "Agatha's Champion" },
                    { 34, "Agatha's Soul Cauldron" },
                    { 35, "Agency Coroner" },
                    { 36, "Agency Outfitter" },
                    { 37, "Aggressive Sabotage" },
                    { 38, "Agrus Kos, Spirit of Justice" },
                    { 39, "Airlift Chaplain" },
                    { 40, "Air Marshal" },
                    { 41, "Airtight Alibi" },
                    { 42, "Ajani, Sleeper Agent" },
                    { 43, "Akal Pakal, First Among Equals" },
                    { 44, "Akawalli, the Seething Tower" },
                    { 45, "A Killer Among Us" },
                    { 46, "Akki Scrapchomper" },
                    { 47, "Akul the Unrepentant" },
                    { 48, "Alabaster Host Intercessor" },
                    { 49, "Alabaster Host Sanctifier" },
                    { 50, "Alania, Divergent Storm" },
                    { 51, "Alania's Pathmaker" },
                    { 52, "Alley Assailant" },
                    { 53, "Alloy Animist" },
                    { 54, "All Will Be One" },
                    { 55, "Aloe Alchemist" },
                    { 56, "Alquist Proft, Master Sleuth" },
                    { 57, "Altanak, the Thrice-Called" },
                    { 58, "Amalia Benavides Aguirre" },
                    { 59, "Ambulatory Edifice" },
                    { 60, "Ambush Gigapede" },
                    { 61, "Ambush Paratrooper" },
                    { 62, "Analyze the Pollen" },
                    { 63, "Ancestors' Aid" },
                    { 64, "Ancestral Reminiscence" },
                    { 65, "Ancient Cornucopia" },
                    { 66, "Ancient Imperiosaur" },
                    { 67, "Angelic Intervention" },
                    { 68, "Animist's Might" },
                    { 69, "Anim Pakal, Thousandth Moon" },
                    { 70, "Ankle Biter" },
                    { 71, "Annex Sentry" },
                    { 72, "Annie Flash, the Veteran" },
                    { 73, "Annie Joins Up" },
                    { 74, "Annihilating Glare" },
                    { 75, "Anointed Peacekeeper" },
                    { 76, "Anoint with Affliction" },
                    { 77, "Another Chance" },
                    { 78, "Another Round" },
                    { 79, "Anthropede" },
                    { 80, "Anzrag's Rampage" },
                    { 81, "Anzrag, the Quake-Mole" },
                    { 82, "Apostle of Invasion" },
                    { 83, "Appendage Amalgam" },
                    { 84, "Aquatic Alchemist" },
                    { 85, "Arabella, Abandoned Doll" },
                    { 86, "Arachnoid Adaptation" }
                });

            migrationBuilder.InsertData(
                table: "Decks",
                columns: new[] { "DeckId", "Cards", "DeckName" },
                values: new object[] { 1, "[\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\",\"Plains\"]", "Sample Deck" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Decks");
        }
    }
}
