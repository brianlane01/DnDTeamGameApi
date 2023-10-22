using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnDTeamGame.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingMoreElements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "GameDescription",
                table: "Games",
                type: "nvarchar(max)",
                maxLength: 7500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "DateCreated", "DateModified", "GameDescription", "GameName", "UserId" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2023, 10, 22, 13, 53, 29, 69, DateTimeKind.Unspecified).AddTicks(3130), new TimeSpan(0, -4, 0, 0, 0)), null, "In a realm where magic and might coexist, the land teeters on the precipice of darkness.\nUnlikely heros must rise up, each from vastly different backgrounds, to embark on a journey\nthat will determine the fate of their world. These four heroes are on separate paths, yet the \nechoes of their destinies are inextricably linked. As they come together, they will unlock the secrets \nof ancient artifacts, face unspeakable evils, and unite against a malevolent force that threatens to plunge \nthe world into darkness. Welcome to a world of magic, valor, cunning, and the unknown. The fate of the realm rests \nin your hands. Will you rise to the occasion and uncover the truth behind the Rise of the Ancients", "Into the Heart of Darkness", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "GameDescription",
                table: "Games",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 7500);
        }
    }
}
