using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnDTeamGame.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddVehicleEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VehicleSpeed = table.Column<double>(type: "float", nullable: false),
                    VehicleAbility = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VehicleType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VehicleDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    VehicleAttackDamage = table.Column<int>(type: "int", nullable: false),
                    VehicleHealth = table.Column<double>(type: "float", nullable: false),
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
