using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnDTeamGame.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMapTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Maps",
                columns: table => new
                {
                    MapId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MapName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MapType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MapDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsDayTime = table.Column<bool>(type: "bit", nullable: false),
                    PrecipitationType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maps", x => x.MapId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Maps");
        }
    }
}
