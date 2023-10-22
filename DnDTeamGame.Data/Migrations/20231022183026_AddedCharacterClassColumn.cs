using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnDTeamGame.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedCharacterClassColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClassBackstoryForCharacter",
                table: "CharacterClasses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "CharacterClasses",
                keyColumn: "CharacterClassId",
                keyValue: 1,
                column: "ClassBackstoryForCharacter",
                value: "You hail from a long line of noble knights sworn to protect the kingdom. Trained in the art of combat \nfrom a young age, you became a renowned warrior and commander of the royal army. Beneath your stoic \nexterior lies a burning desire to uncover the truth about a dark prophecy that foretells the return of \nan ancient evil. As the kingdom teeters on the brink of chaos, you decide to take up the sword, determined \nto fulfill the family's oath and vanquish the looming threat.");

            migrationBuilder.UpdateData(
                table: "CharacterClasses",
                keyColumn: "CharacterClassId",
                keyValue: 2,
                column: "ClassBackstoryForCharacter",
                value: " You have become a skilled hunter, hailing from the Elven Woodlands. The connection you have with the natural world and mastery of archery have made you\na renowned protector of the forest. You joins the other heroes, using your keen senses to detect the malevolent forces\nthreatening the realm. This is not only a quest to safeguard the homeland but also to restore the balance of nature.");

            migrationBuilder.UpdateData(
                table: "CharacterClasses",
                keyColumn: "CharacterClassId",
                keyValue: 3,
                column: "ClassBackstoryForCharacter",
                value: " You grew up an orphan on the unforgiving streets of the shadowy city of Rogarth. Your life of \npetty theft and cunning escapes changed when you discovered a cryptic map, hinting at the existence of an\nartifact that could shift the balance of power in the kingdom. Your past as a rogue makes you an invaluable  \nasset in infiltrating dangerous territories, and you are driven to find the artifact and secure the future.");

            migrationBuilder.UpdateData(
                table: "CharacterClasses",
                keyColumn: "CharacterClassId",
                keyValue: 4,
                column: "ClassBackstoryForCharacter",
                value: " You have becoma a gifted mage, spending your youth studying the arcane arts in the Tower of Mysteries. \nYou now possess a unique ability to see glimpses of the future through magic. The visions reveal an imminent \ncataclysm that threatens to plunge the world into darkness. To avert this fate, you must harness your powers \nand unite with other heroes to unlock the secrets hidden within ancient artifacts, preventing the oncoming disaster.");

            migrationBuilder.UpdateData(
                table: "CharacterClasses",
                keyColumn: "CharacterClassId",
                keyValue: 5,
                column: "ClassBackstoryForCharacter",
                value: "You were once a valiant knight, but corruption took hold when you were raised from the dead as a death knight by a malevolent necromancer.\ntormented by your past deeds, you now seek redemption. Using your unholy powers are harnessing them for a noble cause:\nto vanquish the darkness you once served. Your presence serves as a constant reminder of the thin line between light and shadow.");

            migrationBuilder.UpdateData(
                table: "CharacterClasses",
                keyColumn: "CharacterClassId",
                keyValue: 6,
                column: "ClassBackstoryForCharacter",
                value: "A Dawnbringer, a devoted paladin of a divine order, you set out on a quest with a sacred purpose.\nYour unwavering faith is guided by visions of an ancient prophecy, which you believes holds the key to thwarting the ancient evil.\nArmed with holy magic and a deep sense of duty, You represent the light's beacon in the darkest of times.");

            migrationBuilder.UpdateData(
                table: "CharacterClasses",
                keyColumn: "CharacterClassId",
                keyValue: 7,
                column: "ClassBackstoryForCharacter",
                value: " a brilliant engineer, has dedicated his life to inventing ingenious contraptions. The mysterious artifacts \ndiscovered in the ruins of the acients reveal their dark secrets to you. As an inventor, your knowledge \nof machinery and gadgets makes you a vital ally in deciphering the ancient devices that hold the power to avert the impending catastrophe.");

            migrationBuilder.UpdateData(
                table: "CharacterClasses",
                keyColumn: "CharacterClassId",
                keyValue: 8,
                column: "ClassBackstoryForCharacter",
                value: "You have been an outcast, shunned for the mastery over the dark arts of necromancy. Your affinity for \ncommunicating with the spirits of the deceased led you to uncover an ancient curse that has bound restless souls\nto the world. Your quest is to break the curse, not only to gain acceptance among the living but also to liberate the \n tormented spirits. In the course of the journey, you cross paths with other heroes, forming an unlikely alliance to combat the common threat.");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 10, 22, 14, 30, 26, 833, DateTimeKind.Unspecified).AddTicks(5300), new TimeSpan(0, -4, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassBackstoryForCharacter",
                table: "CharacterClasses");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 10, 22, 13, 53, 29, 69, DateTimeKind.Unspecified).AddTicks(3130), new TimeSpan(0, -4, 0, 0, 0)));
        }
    }
}
