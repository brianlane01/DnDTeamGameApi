using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnDTeamGame.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatestoSeedInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Abilities",
                keyColumn: "AbilityId",
                keyValue: 1,
                columns: new[] { "AbilityDescription", "AbilityEffectType" },
                values: new object[] { " Invisibility, considered to be the supreme form of camouflage, as it does not reveal to the viewer any kind of vital \n signs, visual effects, or any frequencies of the electromagnetic spectrum detectable to the human eye, instead making \n use of radio, infrared or ultraviolet wavelengths.", " Physical Status Effect" });

            migrationBuilder.UpdateData(
                table: "Abilities",
                keyColumn: "AbilityId",
                keyValue: 3,
                columns: new[] { "AbilityDescription", "AbilityEffectType" },
                values: new object[] { " A seven-hit skill that consists of various slashes, several full circle spins and a backwards somersault.", " Sword Attack Ability" });

            migrationBuilder.UpdateData(
                table: "Abilities",
                keyColumn: "AbilityId",
                keyValue: 4,
                column: "AbilityDescription",
                value: " A defence skill that increases the player's Defence for a single second to such an extent that their entire \n body becomes harder than a set of full plate armour. Activation requires the player to be unarmed and only \n wearing non-metallic armour.");

            migrationBuilder.UpdateData(
                table: "Armours",
                keyColumn: "ArmourId",
                keyValue: 1,
                columns: new[] { "ArmourDescription", "ArmourName" },
                values: new object[] { " A suit of armor made from the scales of a dragon, offering excellent protection against fire and other elemental attacks.", " Dragon Scale Mail" });

            migrationBuilder.UpdateData(
                table: "Armours",
                keyColumn: "ArmourId",
                keyValue: 2,
                columns: new[] { "ArmourDescription", "ArmourName" },
                values: new object[] { " Lightweight and finely crafted armor of the elves, known for its flexibility and grace.", " Elven Chainmail" });

            migrationBuilder.UpdateData(
                table: "Armours",
                keyColumn: "ArmourId",
                keyValue: 3,
                column: "ArmourDescription",
                value: " An ornate and majestic suit of armor that grants the wearer resistance to fire damage and the ability \n to rise from the ashes once per day.");

            migrationBuilder.UpdateData(
                table: "Armours",
                keyColumn: "ArmourId",
                keyValue: 4,
                column: "ArmourDescription",
                value: " A dark and stealthy cloak that shrouds the wearer in shadows, making them harder to detect.");

            migrationBuilder.UpdateData(
                table: "Armours",
                keyColumn: "ArmourId",
                keyValue: 7,
                column: "ArmourDescription",
                value: " Enigmatic robes that empower warlocks with eldritch magic and otherworldly abilities.");

            migrationBuilder.UpdateData(
                table: "Armours",
                keyColumn: "ArmourId",
                keyValue: 8,
                columns: new[] { "ArmourDescription", "ArmourName" },
                values: new object[] { " A lightweight, silvery chainmail made from mithril, providing excellent protection without hindering mobility.", " Mithril Chain" });

            migrationBuilder.UpdateData(
                table: "Armours",
                keyColumn: "ArmourId",
                keyValue: 9,
                columns: new[] { "ArmourDescription", "ArmourName" },
                values: new object[] { " Crafted from the hide of a kraken, this armor provides resistance to aquatic threats and great flexibility.", " Kraken Hide Armor" });

            migrationBuilder.UpdateData(
                table: "Armours",
                keyColumn: "ArmourId",
                keyValue: 10,
                columns: new[] { "ArmourDescription", "ArmourName" },
                values: new object[] { " A sleek and agile leather vest favored by rogues and thieves, providing ease of movement and subtlety.", " Leather Vest of the Rogue" });

            migrationBuilder.UpdateData(
                table: "CharacterClasses",
                keyColumn: "CharacterClassId",
                keyValue: 1,
                columns: new[] { "CharacterClassDescription", "ClassBackstoryForCharacter", "SpecialAbilityDescription" },
                values: new object[] { " Warriors equip themselves carefully for combat and engage their enemies head-on, letting attacks glance \n off their heavy armor. They use diverse combat tactics and a wide variety of weapon types to protect \n their more vulnerable allies. Warriors must carefully master their rage, the power behind their strongest \n attacks in order to maximize their effectiveness in combat.", " You hail from a long line of noble knights sworn to protect the kingdom. Trained in the art of combat \n from a young age, you became a renowned warrior and commander of the royal army. Beneath your stoic \n exterior lies a burning desire to uncover the truth about a dark prophecy that foretells the return of \n an ancient evil. As the kingdom teeters on the brink of chaos, you decide to take up the sword, determined \n to fulfill the family's oath and vanquish the looming threat.", " As warriors deal or take damage, their rage grows, allowing them to deliver truly crushing attacks in the heat of battle." });

            migrationBuilder.UpdateData(
                table: "CharacterClasses",
                keyColumn: "CharacterClassId",
                keyValue: 2,
                columns: new[] { "CharacterClassDescription", "ClassBackstoryForCharacter", "SpecialAbilityDescription" },
                values: new object[] { " Hunters battle their foes at a distance or up close, commanding their pets to attack while they nock their arrows, \n fire their guns, or ready their polearms. Though their weapons are effective at short and long ranges, hunters are \n also highly mobile. They can evade or restrain their foes to control the arena of battle", " You have become a skilled hunter, hailing from the Elven Woodlands. The connection you have with the natural world \n and mastery of archery have made you\n a renowned protector of the forest. You joins the other heroes, using your keen senses to detect the malevolent forces\n threatening the realm. This is not only a quest to safeguard the homeland but also to restore the balance of nature.", " Hunters tame the beasts of the wild, and those beasts serve in return by assaulting their enemies and shielding them from harm." });

            migrationBuilder.UpdateData(
                table: "CharacterClasses",
                keyColumn: "CharacterClassId",
                keyValue: 3,
                columns: new[] { "CharacterClassDescription", "ClassBackstoryForCharacter", "SpecialAbilityDescription" },
                values: new object[] { "  Rogues often initiate combat with a surprise attack from the shadows, leading with vicious melee strikes.\n  When in protracted battles, they utilize a successive combination of carefully chosen attacks to soften the \n  enemy up for a killing blow. Rogues must take special care when selecting targets so that their combo attacks \n  are not wasted, and they must be conscious of when to hide or flee if a battle turns against them.", " You grew up an orphan on the unforgiving streets of the shadowy city of Rogarth. Your life of \n petty theft and cunning escapes changed when you discovered a cryptic map, hinting at the existence of an\n artifact that could shift the balance of power in the kingdom. Your past as a rogue makes you an invaluable  \n asset in infiltrating dangerous territories, and you are driven to find the artifact and secure the future.", " Rogues sneak about the battlefield, hiding from enemies and delivering surprise attacks to the unwary when opportunity arises." });

            migrationBuilder.UpdateData(
                table: "CharacterClasses",
                keyColumn: "CharacterClassId",
                keyValue: 4,
                columns: new[] { "CharacterClassDescription", "ClassBackstoryForCharacter", "SpecialAbilityDescription" },
                values: new object[] { "  Mages demolish their foes with arcane incantations. Although they wield powerful offensive spells, mages are \n  fragile and lightly armored, making them particularly vulnerable to close-range attacks. Wise mages make \n  careful use of their spells to keep their foes at a distance or hold them in place.", "  You have becoma a gifted mage, spending your youth studying the arcane arts in the Tower of Mysteries. \n  You now possess a unique ability to see glimpses of the future through magic. The visions reveal an imminent \n  cataclysm that threatens to plunge the world into darkness. To avert this fate, you must harness your powers \n  and unite with other heroes to unlock the secrets hidden within ancient artifacts, preventing the oncoming disaster.", "  By calling upon sheets of ice, columns of flame, and waves of arcane power, mages can effectively \n  attack multiple foes at the same time." });

            migrationBuilder.UpdateData(
                table: "CharacterClasses",
                keyColumn: "CharacterClassId",
                keyValue: 5,
                columns: new[] { "CharacterClassDescription", "ClassBackstoryForCharacter", "SpecialAbilityDescription" },
                values: new object[] { "  Death Knights engage their foes up-close, supplementing swings of their weapons with dark magic that renders \n  enemies vulnerable or damages them with unholy power. They drag foes into one-on-one conflicts, compelling \n  them to focus their attacks away from weaker companions. To prevent their enemies from fleeing their grasp, \n  death knights must remain mindful of the power they call forth from runes, and pace their attacks appropriately.", "  You were once a valiant knight, but corruption took hold when you were raised from the dead as a death knight by a malevolent necromancer.\n  tormented by your past deeds, you now seek redemption. Using your unholy powers are harnessing them for a noble cause:\n  to vanquish the darkness you once served. Your presence serves as a constant reminder of the thin line between light and shadow.", "  Death knight runeblades are empowered with dark magic; they can expend the power of their runes for vicious attacks." });

            migrationBuilder.UpdateData(
                table: "CharacterClasses",
                keyColumn: "CharacterClassId",
                keyValue: 6,
                columns: new[] { "CharacterClassDescription", "ClassBackstoryForCharacter", "SpecialAbilityDescription" },
                values: new object[] { "  Paladins stand directly in front of their enemies, relying on heavy armor and healing in order to survive incoming \n  attacks. Whether with massive shields or crushing two-handed weapons, Paladins are able to keep claws and swords from \n  their weaker fellows or they use healing magic to ensure that they remain on their feet.", "  A Dawnbringer, a devoted paladin of a divine order, you set out on a quest with a sacred purpose.\n  Your unwavering faith is guided by visions of an ancient prophecy, which you believes holds the key to thwarting the ancient evil.\n  Armed with holy magic and a deep sense of duty, You represent the light's beacon in the darkest of times.", "  Paladins potent healing abilities can ensure that they and their allies remain in fighting shape." });

            migrationBuilder.UpdateData(
                table: "CharacterClasses",
                keyColumn: "CharacterClassId",
                keyValue: 7,
                columns: new[] { "CharacterClassDescription", "ClassBackstoryForCharacter", "SpecialAbilityDescription" },
                values: new object[] { "  Masters of mechanical mayhem, engineers love to tinker with explosives, elixirs, and all manner of hazardous gadgets. \n  They support their allies with alchemic weaponry, deploy ingenious inventions, or lay waste to foes with a wide array \n  of mines, bombs, and grenades.", "  You have become a brilliant engineer, dedicating your life to inventing ingenious contraptions. The mysterious artifacts \n  discovered in the ruins of the acients reveal their dark secrets to you. As an inventor, your knowledge \n  of machinery and gadgets makes you a vital ally in deciphering the ancient devices that hold the power to \n  avert the impending catastrophe.", "  An engineer constructs turrets to help defend and control an area. These devices can pound the ground to damage enemies, \n  disperse healing mist to aid allies, fire off rockets, and more." });

            migrationBuilder.UpdateData(
                table: "CharacterClasses",
                keyColumn: "CharacterClassId",
                keyValue: 8,
                columns: new[] { "CharacterClassDescription", "ClassBackstoryForCharacter", "SpecialAbilityDescription" },
                values: new object[] { " Practitioners of the dark arts, necromancers summon minions, wield the power of ritual, and heal themselves with \n blood magic. Necromancers feed on life force, which they can leverage offensively or use to delay their own demise.", "  You have been an outcast, shunned for the mastery over the dark arts of necromancy. Your affinity for \n  communicating with the spirits of the deceased led you to uncover an ancient curse that has bound restless souls\n  to the world. Your quest is to break the curse, not only to gain acceptance among the living but also to liberate the \n  tormented spirits. In the course of the journey, you cross paths with other heroes, forming an unlikely alliance \n  to combat the common threat.", "  Life force is a special type of energy that necromancers draw from their enemies. Once theyve collected enough \n  life force, necromancers can activate their Death Shroud, entering a spirit form. Life force can be gathered \n  from certain weapon attacks and especially from deaths that happen near the necromancer." });

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "ConsumableId",
                keyValue: 1,
                columns: new[] { "ConsumableDescription", "ConsumableEffect" },
                values: new object[] { " A magical potion that restores a portion of your health.", " Restores 50 health points." });

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "ConsumableId",
                keyValue: 2,
                columns: new[] { "ConsumableDescription", "ConsumableEffect" },
                values: new object[] { "  A potent elixir that temporarily enhances your defensive capabilities.", "  Increases your defense by 20% for 3 minutes." });

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "ConsumableId",
                keyValue: 3,
                columns: new[] { "ConsumableDescription", "ConsumableEffect" },
                values: new object[] { "  A strong potion that grants you temporary, furious strength in battle.", "  Increases your attack damage by 30% for 2 minutes but decreases defense by 15%." });

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "ConsumableId",
                keyValue: 4,
                columns: new[] { "ConsumableDamageToEnemy", "ConsumableDescription", "ConsumableEffect" },
                values: new object[] { "  Paralyze Enemy for 15 Seconds", "  A mystical stone with the petrifying power of the Gorgon.", "  Can be used to temporarily paralyze or petrify enemies." });

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "ConsumableId",
                keyValue: 5,
                columns: new[] { "ConsumableDamageToEnemy", "ConsumableEffect" },
                values: new object[] { " Paralyze Enemy for 15 Seconds", "  Grants a temporary energy shield that reflects incoming projectiles." });

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "ConsumableId",
                keyValue: 6,
                columns: new[] { "ConsumableDescription", "ConsumableEffect" },
                values: new object[] { "  An ancient scroll with the power to instantly teleport \n  the user to a previously visited location.", "  Teleports you to a known location on the map." });

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "ConsumableId",
                keyValue: 7,
                columns: new[] { "ConsumableDescription", "ConsumableEffect" },
                values: new object[] { "  A rare and delicious fruit said to grant immortality in mythology.", "  Fully restores health and grants temporary invincibility." });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 1,
                columns: new[] { "DateCreated", "GameDescription" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 10, 26, 14, 33, 42, 693, DateTimeKind.Unspecified).AddTicks(3690), new TimeSpan(0, -4, 0, 0, 0)), "In a realm where magic and might coexist, the land teeters on the precipice of darkness.\n|  Unlikely heros must rise up, each from vastly different backgrounds, to embark on a journey\n| that will determine the fate of their world. These four heroes are on separate paths, yet the \n|  echoes of their destinies are inextricably linked. As they come together, they will unlock the secrets \n| of ancient artifacts, face unspeakable evils, and unite against a malevolent force that threatens to plunge \n|  the world into darkness. Welcome to a world of magic, valor, cunning, and the unknown. The fate of the realm rests \n|  in your hands. Will you rise to the occasion and uncover the truth behind the Rise of the Ancients" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                column: "VehicleDescription",
                value: " A powerful warhorse trained for battle, capable of charging into enemy lines.");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                column: "VehicleDescription",
                value: " A majestic airship that soars through the skies, offering great mobility and firepower.");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                column: "VehicleDescription",
                value: " A massive mechanical walker armed with heavy artillery, capable of withstanding immense damage.");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                column: "VehicleDescription",
                value: " A massive, fearsome wolf that serves as a mount for those brave enough to tame it. Known for its \n speed and strength, it's a formidable ally in battle.");

            migrationBuilder.UpdateData(
                table: "Weapons",
                keyColumn: "WeaponId",
                keyValue: 1,
                column: "WeaponDescription",
                value: " A radiant bow blessed by celestial beings, firing arrows of divine light that can smite darkness and heal allies.");

            migrationBuilder.UpdateData(
                table: "Weapons",
                keyColumn: "WeaponId",
                keyValue: 4,
                columns: new[] { "WeaponName", "WeaponType" },
                values: new object[] { " Vorpal Blade", " Katana" });

            migrationBuilder.UpdateData(
                table: "Weapons",
                keyColumn: "WeaponId",
                keyValue: 5,
                columns: new[] { "WeaponName", "WeaponType" },
                values: new object[] { " Dwarven Warhammer", " WarHammer" });

            migrationBuilder.UpdateData(
                table: "Weapons",
                keyColumn: "WeaponId",
                keyValue: 6,
                columns: new[] { "WeaponDescription", "WeaponName", "WeaponType" },
                values: new object[] { " A menacing scythe associated with necromancers, capable of harvesting souls and controlling the undead.", " Necromancer's Scythe", " Scythe" });

            migrationBuilder.UpdateData(
                table: "Weapons",
                keyColumn: "WeaponId",
                keyValue: 9,
                columns: new[] { "WeaponDescription", "WeaponName", "WeaponType" },
                values: new object[] { " The legendary sword of King Arthur, said to be the most powerful and righteous weapon in the realm, capable of vanquishing evil.", " Excalibur", " Sword" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Abilities",
                keyColumn: "AbilityId",
                keyValue: 1,
                columns: new[] { "AbilityDescription", "AbilityEffectType" },
                values: new object[] { "Invisibility, considered to be the supreme form of camouflage, as it does not reveal to the viewer any kind of vital \nsigns, visual effects, or any frequencies of the electromagnetic spectrum detectable to the human eye, instead making \nuse of radio, infrared or ultraviolet wavelengths.", "Physical Status Effect" });

            migrationBuilder.UpdateData(
                table: "Abilities",
                keyColumn: "AbilityId",
                keyValue: 3,
                columns: new[] { "AbilityDescription", "AbilityEffectType" },
                values: new object[] { "A seven-hit skill that consists of various slashes, several full circle spins and a backwards somersault.", "Sword Attack Ability" });

            migrationBuilder.UpdateData(
                table: "Abilities",
                keyColumn: "AbilityId",
                keyValue: 4,
                column: "AbilityDescription",
                value: "A defence skill that increases the player's Defence for a single second to such an extent that their entire \nbody becomes harder than a set of full plate armour. Activation requires the player to be unarmed and only \nwearing non-metallic armour.");

            migrationBuilder.UpdateData(
                table: "Armours",
                keyColumn: "ArmourId",
                keyValue: 1,
                columns: new[] { "ArmourDescription", "ArmourName" },
                values: new object[] { "A suit of armor made from the scales of a dragon, offering excellent protection against fire and other elemental attacks.", "Dragon Scale Mail" });

            migrationBuilder.UpdateData(
                table: "Armours",
                keyColumn: "ArmourId",
                keyValue: 2,
                columns: new[] { "ArmourDescription", "ArmourName" },
                values: new object[] { "Lightweight and finely crafted armor of the elves, known for its flexibility and grace.", "Elven Chainmail" });

            migrationBuilder.UpdateData(
                table: "Armours",
                keyColumn: "ArmourId",
                keyValue: 3,
                column: "ArmourDescription",
                value: "An ornate and majestic suit of armor that grants the wearer resistance to fire damage and the ability \nto rise from the ashes once per day.");

            migrationBuilder.UpdateData(
                table: "Armours",
                keyColumn: "ArmourId",
                keyValue: 4,
                column: "ArmourDescription",
                value: "A dark and stealthy cloak that shrouds the wearer in shadows, making them harder to detect.");

            migrationBuilder.UpdateData(
                table: "Armours",
                keyColumn: "ArmourId",
                keyValue: 7,
                column: "ArmourDescription",
                value: "Enigmatic robes that empower warlocks with eldritch magic and otherworldly abilities.");

            migrationBuilder.UpdateData(
                table: "Armours",
                keyColumn: "ArmourId",
                keyValue: 8,
                columns: new[] { "ArmourDescription", "ArmourName" },
                values: new object[] { "A lightweight, silvery chainmail made from mithril, providing excellent protection without hindering mobility.", "Mithril Chain" });

            migrationBuilder.UpdateData(
                table: "Armours",
                keyColumn: "ArmourId",
                keyValue: 9,
                columns: new[] { "ArmourDescription", "ArmourName" },
                values: new object[] { "Crafted from the hide of a kraken, this armor provides resistance to aquatic threats and great flexibility.", "Kraken Hide Armor" });

            migrationBuilder.UpdateData(
                table: "Armours",
                keyColumn: "ArmourId",
                keyValue: 10,
                columns: new[] { "ArmourDescription", "ArmourName" },
                values: new object[] { "A sleek and agile leather vest favored by rogues and thieves, providing ease of movement and subtlety.", "Leather Vest of the Rogue" });

            migrationBuilder.UpdateData(
                table: "CharacterClasses",
                keyColumn: "CharacterClassId",
                keyValue: 1,
                columns: new[] { "CharacterClassDescription", "ClassBackstoryForCharacter", "SpecialAbilityDescription" },
                values: new object[] { "Warriors equip themselves carefully for combat and engage their enemies head-on, letting attacks glance \noff their heavy armor. They use diverse combat tactics and a wide variety of weapon types to protect \ntheir more vulnerable allies. Warriors must carefully master their rage, the power behind their strongest \nattacks in order to maximize their effectiveness in combat.", "You hail from a long line of noble knights sworn to protect the kingdom. Trained in the art of combat \nfrom a young age, you became a renowned warrior and commander of the royal army. Beneath your stoic \nexterior lies a burning desire to uncover the truth about a dark prophecy that foretells the return of \nan ancient evil. As the kingdom teeters on the brink of chaos, you decide to take up the sword, determined \nto fulfill the family's oath and vanquish the looming threat.", "As warriors deal or take damage, their rage grows, allowing them to deliver truly crushing attacks in the heat of battle." });

            migrationBuilder.UpdateData(
                table: "CharacterClasses",
                keyColumn: "CharacterClassId",
                keyValue: 2,
                columns: new[] { "CharacterClassDescription", "ClassBackstoryForCharacter", "SpecialAbilityDescription" },
                values: new object[] { "Hunters battle their foes at a distance or up close, commanding their pets to attack while they nock their arrows, \nfire their guns, or ready their polearms. Though their weapons are effective at short and long ranges, hunters are \nalso highly mobile. They can evade or restrain their foes to control the arena of battle", " You have become a skilled hunter, hailing from the Elven Woodlands. The connection you have with the natural world \nand mastery of archery have made you\na renowned protector of the forest. You joins the other heroes, using your keen senses to detect the malevolent forces\nthreatening the realm. This is not only a quest to safeguard the homeland but also to restore the balance of nature.", "Hunters tame the beasts of the wild, and those beasts serve in return by assaulting their enemies and shielding them from harm." });

            migrationBuilder.UpdateData(
                table: "CharacterClasses",
                keyColumn: "CharacterClassId",
                keyValue: 3,
                columns: new[] { "CharacterClassDescription", "ClassBackstoryForCharacter", "SpecialAbilityDescription" },
                values: new object[] { "Rogues often initiate combat with a surprise attack from the shadows, leading with vicious melee strikes.\nWhen in protracted battles, they utilize a successive combination of carefully chosen attacks to soften the \nenemy up for a killing blow. Rogues must take special care when selecting targets so that their combo attacks \nare not wasted, and they must be conscious of when to hide or flee if a battle turns against them.", " You grew up an orphan on the unforgiving streets of the shadowy city of Rogarth. Your life of \npetty theft and cunning escapes changed when you discovered a cryptic map, hinting at the existence of an\nartifact that could shift the balance of power in the kingdom. Your past as a rogue makes you an invaluable  \nasset in infiltrating dangerous territories, and you are driven to find the artifact and secure the future.", "Rogues sneak about the battlefield, hiding from enemies and delivering surprise attacks to the unwary when opportunity arises." });

            migrationBuilder.UpdateData(
                table: "CharacterClasses",
                keyColumn: "CharacterClassId",
                keyValue: 4,
                columns: new[] { "CharacterClassDescription", "ClassBackstoryForCharacter", "SpecialAbilityDescription" },
                values: new object[] { "Mages demolish their foes with arcane incantations. Although they wield powerful offensive spells, mages are \nfragile and lightly armored, making them particularly vulnerable to close-range attacks. Wise mages make \ncareful use of their spells to keep their foes at a distance or hold them in place.", " You have becoma a gifted mage, spending your youth studying the arcane arts in the Tower of Mysteries. \nYou now possess a unique ability to see glimpses of the future through magic. The visions reveal an imminent \ncataclysm that threatens to plunge the world into darkness. To avert this fate, you must harness your powers \nand unite with other heroes to unlock the secrets hidden within ancient artifacts, preventing the oncoming disaster.", "By calling upon sheets of ice, columns of flame, and waves of arcane power, mages can effectively \nattack multiple foes at the same time." });

            migrationBuilder.UpdateData(
                table: "CharacterClasses",
                keyColumn: "CharacterClassId",
                keyValue: 5,
                columns: new[] { "CharacterClassDescription", "ClassBackstoryForCharacter", "SpecialAbilityDescription" },
                values: new object[] { "Death Knights engage their foes up-close, supplementing swings of their weapons with dark magic that renders \nenemies vulnerable or damages them with unholy power. They drag foes into one-on-one conflicts, compelling \nthem to focus their attacks away from weaker companions. To prevent their enemies from fleeing their grasp, \ndeath knights must remain mindful of the power they call forth from runes, and pace their attacks appropriately.", "You were once a valiant knight, but corruption took hold when you were raised from the dead as a death knight by a malevolent necromancer.\ntormented by your past deeds, you now seek redemption. Using your unholy powers are harnessing them for a noble cause:\nto vanquish the darkness you once served. Your presence serves as a constant reminder of the thin line between light and shadow.", "Death knight runeblades are empowered with dark magic; they can expend the power of their runes for vicious attacks." });

            migrationBuilder.UpdateData(
                table: "CharacterClasses",
                keyColumn: "CharacterClassId",
                keyValue: 6,
                columns: new[] { "CharacterClassDescription", "ClassBackstoryForCharacter", "SpecialAbilityDescription" },
                values: new object[] { "Paladins stand directly in front of their enemies, relying on heavy armor and healing in order to survive incoming \nattacks. Whether with massive shields or crushing two-handed weapons, Paladins are able to keep claws and swords from \ntheir weaker fellows or they use healing magic to ensure that they remain on their feet.", "A Dawnbringer, a devoted paladin of a divine order, you set out on a quest with a sacred purpose.\nYour unwavering faith is guided by visions of an ancient prophecy, which you believes holds the key to thwarting the ancient evil.\nArmed with holy magic and a deep sense of duty, You represent the light's beacon in the darkest of times.", "Paladins potent healing abilities can ensure that they and their allies remain in fighting shape." });

            migrationBuilder.UpdateData(
                table: "CharacterClasses",
                keyColumn: "CharacterClassId",
                keyValue: 7,
                columns: new[] { "CharacterClassDescription", "ClassBackstoryForCharacter", "SpecialAbilityDescription" },
                values: new object[] { "Masters of mechanical mayhem, engineers love to tinker with explosives, elixirs, and all manner of hazardous gadgets. \nThey support their allies with alchemic weaponry, deploy ingenious inventions, or lay waste to foes with a wide array \nof mines, bombs, and grenades.", " You have become a brilliant engineer, dedicating your life to inventing ingenious contraptions. The mysterious artifacts \ndiscovered in the ruins of the acients reveal their dark secrets to you. As an inventor, your knowledge \nof machinery and gadgets makes you a vital ally in deciphering the ancient devices that hold the power to \navert the impending catastrophe.", "An engineer constructs turrets to help defend and control an area. These devices can pound the ground to damage enemies, \ndisperse healing mist to aid allies, fire off rockets, and more." });

            migrationBuilder.UpdateData(
                table: "CharacterClasses",
                keyColumn: "CharacterClassId",
                keyValue: 8,
                columns: new[] { "CharacterClassDescription", "ClassBackstoryForCharacter", "SpecialAbilityDescription" },
                values: new object[] { "Practitioners of the dark arts, necromancers summon minions, wield the power of ritual, and heal themselves with \nblood magic. Necromancers feed on life force, which they can leverage offensively or use to delay their own demise.", "You have been an outcast, shunned for the mastery over the dark arts of necromancy. Your affinity for \ncommunicating with the spirits of the deceased led you to uncover an ancient curse that has bound restless souls\nto the world. Your quest is to break the curse, not only to gain acceptance among the living but also to liberate the \n tormented spirits. In the course of the journey, you cross paths with other heroes, forming an unlikely alliance \nto combat the common threat.", "Life force is a special type of energy that necromancers draw from their enemies. Once theyve collected enough \nlife force, necromancers can activate their Death Shroud, entering a spirit form. Life force can be gathered \nfrom certain weapon attacks and especially from deaths that happen near the necromancer." });

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "ConsumableId",
                keyValue: 1,
                columns: new[] { "ConsumableDescription", "ConsumableEffect" },
                values: new object[] { "A magical potion that restores a portion of your health.", "Restores 50 health points." });

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "ConsumableId",
                keyValue: 2,
                columns: new[] { "ConsumableDescription", "ConsumableEffect" },
                values: new object[] { "A potent elixir that temporarily enhances your defensive capabilities.", "Increases your defense by 20% for 3 minutes." });

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "ConsumableId",
                keyValue: 3,
                columns: new[] { "ConsumableDescription", "ConsumableEffect" },
                values: new object[] { "A strong potion that grants you temporary, furious strength in battle.", "Increases your attack damage by 30% for 2 minutes but decreases defense by 15%." });

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "ConsumableId",
                keyValue: 4,
                columns: new[] { "ConsumableDamageToEnemy", "ConsumableDescription", "ConsumableEffect" },
                values: new object[] { "Paralyze Enemy for 15 Seconds", "A mystical stone with the petrifying power of the Gorgon.", "Can be used to temporarily paralyze or petrify enemies." });

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "ConsumableId",
                keyValue: 5,
                columns: new[] { "ConsumableDamageToEnemy", "ConsumableEffect" },
                values: new object[] { "Paralyze Enemy for 15 Seconds", "Grants a temporary energy shield that reflects incoming projectiles." });

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "ConsumableId",
                keyValue: 6,
                columns: new[] { "ConsumableDescription", "ConsumableEffect" },
                values: new object[] { "An ancient scroll with the power to instantly teleport \nthe user to a previously visited location.", "Teleports you to a known location on the map." });

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "ConsumableId",
                keyValue: 7,
                columns: new[] { "ConsumableDescription", "ConsumableEffect" },
                values: new object[] { "A rare and delicious fruit said to grant immortality in mythology.", "Fully restores health and grants temporary invincibility." });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 1,
                columns: new[] { "DateCreated", "GameDescription" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 10, 26, 13, 15, 38, 8, DateTimeKind.Unspecified).AddTicks(3860), new TimeSpan(0, -4, 0, 0, 0)), "In a realm where magic and might coexist, the land teeters on the precipice of darkness.\nUnlikely heros must rise up, each from vastly different backgrounds, to embark on a journey\nthat will determine the fate of their world. These four heroes are on separate paths, yet the \nechoes of their destinies are inextricably linked. As they come together, they will unlock the secrets \nof ancient artifacts, face unspeakable evils, and unite against a malevolent force that threatens to plunge \nthe world into darkness. Welcome to a world of magic, valor, cunning, and the unknown. The fate of the realm rests \nin your hands. Will you rise to the occasion and uncover the truth behind the Rise of the Ancients" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                column: "VehicleDescription",
                value: "A powerful warhorse trained for battle, capable of charging into enemy lines.");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                column: "VehicleDescription",
                value: "A majestic airship that soars through the skies, offering great mobility and firepower.");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                column: "VehicleDescription",
                value: "A massive mechanical walker armed with heavy artillery, capable of withstanding immense damage.");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                column: "VehicleDescription",
                value: "A massive, fearsome wolf that serves as a mount for those brave enough to tame it. Known for its \nspeed and strength, it's a formidable ally in battle.");

            migrationBuilder.UpdateData(
                table: "Weapons",
                keyColumn: "WeaponId",
                keyValue: 1,
                column: "WeaponDescription",
                value: "A radiant bow blessed by celestial beings, firing arrows of divine light that can smite darkness and heal allies.");

            migrationBuilder.UpdateData(
                table: "Weapons",
                keyColumn: "WeaponId",
                keyValue: 4,
                columns: new[] { "WeaponName", "WeaponType" },
                values: new object[] { "Vorpal Blade", "Katana" });

            migrationBuilder.UpdateData(
                table: "Weapons",
                keyColumn: "WeaponId",
                keyValue: 5,
                columns: new[] { "WeaponName", "WeaponType" },
                values: new object[] { "Dwarven Warhammer", "WarHammer" });

            migrationBuilder.UpdateData(
                table: "Weapons",
                keyColumn: "WeaponId",
                keyValue: 6,
                columns: new[] { "WeaponDescription", "WeaponName", "WeaponType" },
                values: new object[] { "A menacing scythe associated with necromancers, capable of harvesting souls and controlling the undead.", "Necromancer's Scythe", "Scythe" });

            migrationBuilder.UpdateData(
                table: "Weapons",
                keyColumn: "WeaponId",
                keyValue: 9,
                columns: new[] { "WeaponDescription", "WeaponName", "WeaponType" },
                values: new object[] { "The legendary sword of King Arthur, said to be the most powerful and righteous weapon in the realm, capable of vanquishing evil.", "Excalibur", "Sword" });
        }
    }
}
