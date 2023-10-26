using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DnDTeamGame.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    AbilityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AbilityName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AbilityDescription = table.Column<string>(type: "nvarchar(max)", maxLength: 7500, nullable: false),
                    AbilityEffectType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AbilityEffectAttack = table.Column<bool>(type: "bit", nullable: false),
                    AbilityEffectHealthEnhancement = table.Column<bool>(type: "bit", nullable: false),
                    AbilityEffectDefenseEnhancement = table.Column<bool>(type: "bit", nullable: false),
                    AbilityHasStatusEffect = table.Column<bool>(type: "bit", nullable: false),
                    AbilityDamageSingleEnemy = table.Column<bool>(type: "bit", nullable: false),
                    AbilityDamageMultipleEnemy = table.Column<bool>(type: "bit", nullable: false),
                    AbilityAttackDamage = table.Column<int>(type: "int", nullable: false),
                    AbilityHealingAmount = table.Column<int>(type: "int", nullable: false),
                    AbilityDefenseIncrease = table.Column<int>(type: "int", nullable: false),
                    AbilityEffectTimeLimit = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.AbilityId);
                });

            migrationBuilder.CreateTable(
                name: "Armours",
                columns: table => new
                {
                    ArmourId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArmourName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArmourDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ArmourProvidesDefense = table.Column<bool>(type: "bit", nullable: false),
                    ArmourIncreasesHealth = table.Column<bool>(type: "bit", nullable: false),
                    ArmourIncreasesSwordAttacks = table.Column<bool>(type: "bit", nullable: false),
                    ArmourIncreasesRangedAttacks = table.Column<bool>(type: "bit", nullable: false),
                    IncreasedHealthAmount = table.Column<int>(type: "int", nullable: false),
                    IncreasedSwordDamageAmount = table.Column<int>(type: "int", nullable: false),
                    IncreasedRangeAttackDamageAmount = table.Column<int>(type: "int", nullable: false),
                    IncreasedDefenseAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armours", x => x.ArmourId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BodyTypes",
                columns: table => new
                {
                    BodyTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BodyTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyTypes", x => x.BodyTypeId);
                });

            migrationBuilder.CreateTable(
                name: "CharacterClasses",
                columns: table => new
                {
                    CharacterClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterClassName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CharacterClassDescription = table.Column<string>(type: "nvarchar(750)", maxLength: 750, nullable: false),
                    CharacterClassSpecialAbility = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialAbilityIsAnAttack = table.Column<bool>(type: "bit", nullable: false),
                    SpecialAbilityHeals = table.Column<bool>(type: "bit", nullable: false),
                    SpecialAbilityProvidesDefense = table.Column<bool>(type: "bit", nullable: false),
                    SpecialAbilityProvidesStatusEffect = table.Column<bool>(type: "bit", nullable: false),
                    SpecialAbilityDamage = table.Column<int>(type: "int", nullable: false),
                    SpecialAbilityHealingAmount = table.Column<int>(type: "int", nullable: false),
                    SpeacialAbilityDefenseAmount = table.Column<int>(type: "int", nullable: false),
                    SpecialAbilityDuration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialAbilityDescription = table.Column<string>(type: "nvarchar(750)", maxLength: 750, nullable: false),
                    ClassBackstoryForCharacter = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterClasses", x => x.CharacterClassId);
                });

            migrationBuilder.CreateTable(
                name: "Consumables",
                columns: table => new
                {
                    ConsumableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsumableName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ConsumableDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ConsumableEffect = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ConsumableIncreaseHealth = table.Column<bool>(type: "bit", nullable: false),
                    ConsumableIncreaseDefense = table.Column<bool>(type: "bit", nullable: false),
                    ConsumableIncreaseAttack = table.Column<bool>(type: "bit", nullable: false),
                    ConsumableDoesDamageToEnemy = table.Column<bool>(type: "bit", nullable: false),
                    ConsumableHealthIncreaseAmount = table.Column<int>(type: "int", nullable: true),
                    ConsumableDefenseIncreaseAmount = table.Column<int>(type: "int", nullable: true),
                    ConsumableAttackIncreaseAmount = table.Column<int>(type: "int", nullable: true),
                    ConsumableDamageToEnemy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumables", x => x.ConsumableId);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    GameDescription = table.Column<string>(type: "nvarchar(max)", maxLength: 7500, nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "HairColors",
                columns: table => new
                {
                    HairColorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HairColorName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HairColors", x => x.HairColorId);
                });

            migrationBuilder.CreateTable(
                name: "HairStyles",
                columns: table => new
                {
                    HairStyleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HairStyleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HairStyles", x => x.HairStyleId);
                });

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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

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
                    VehicleHealth = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    WeaponId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeaponName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WeaponType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WeaponDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WeaponIsARangedWeapon = table.Column<bool>(type: "bit", nullable: false),
                    WeaponIsAMeleeWeapon = table.Column<bool>(type: "bit", nullable: false),
                    WeaponGeneratesSplashDamage = table.Column<bool>(type: "bit", nullable: false),
                    RangedWeaponDistance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WeaponDamageAmount = table.Column<int>(type: "int", nullable: false),
                    WeaponSplashDamageAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.WeaponId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
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
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CharacterHealth = table.Column<int>(type: "int", nullable: false),
                    CharacterBaseAttackDamage = table.Column<double>(type: "float", nullable: false),
                    CharacterBaseDefense = table.Column<int>(type: "int", nullable: false),
                    CharacterDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CharacterClassId = table.Column<int>(type: "int", nullable: false),
                    BodyTypeId = table.Column<int>(type: "int", nullable: false),
                    HairStyleId = table.Column<int>(type: "int", nullable: false),
                    HairColorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharacterId);
                    table.ForeignKey(
                        name: "FK_Characters_BodyTypes_BodyTypeId",
                        column: x => x.BodyTypeId,
                        principalTable: "BodyTypes",
                        principalColumn: "BodyTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_CharacterClasses_CharacterClassId",
                        column: x => x.CharacterClassId,
                        principalTable: "CharacterClasses",
                        principalColumn: "CharacterClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_HairColors_HairColorId",
                        column: x => x.HairColorId,
                        principalTable: "HairColors",
                        principalColumn: "HairColorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_HairStyles_HairStyleId",
                        column: x => x.HairStyleId,
                        principalTable: "HairStyles",
                        principalColumn: "HairStyleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbilityEntityCharacterEntity",
                columns: table => new
                {
                    AbilitiesListAbilityId = table.Column<int>(type: "int", nullable: false),
                    CharacterListCharacterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbilityEntityCharacterEntity", x => new { x.AbilitiesListAbilityId, x.CharacterListCharacterId });
                    table.ForeignKey(
                        name: "FK_AbilityEntityCharacterEntity_Abilities_AbilitiesListAbilityId",
                        column: x => x.AbilitiesListAbilityId,
                        principalTable: "Abilities",
                        principalColumn: "AbilityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbilityEntityCharacterEntity_Characters_CharacterListCharacterId",
                        column: x => x.CharacterListCharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArmourEntityCharacterEntity",
                columns: table => new
                {
                    ArmoursListArmourId = table.Column<int>(type: "int", nullable: false),
                    CharacterListCharacterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmourEntityCharacterEntity", x => new { x.ArmoursListArmourId, x.CharacterListCharacterId });
                    table.ForeignKey(
                        name: "FK_ArmourEntityCharacterEntity_Armours_ArmoursListArmourId",
                        column: x => x.ArmoursListArmourId,
                        principalTable: "Armours",
                        principalColumn: "ArmourId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArmourEntityCharacterEntity_Characters_CharacterListCharacterId",
                        column: x => x.CharacterListCharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterEntityConsumableEntity",
                columns: table => new
                {
                    CharacterListCharacterId = table.Column<int>(type: "int", nullable: false),
                    ConsumablesListConsumableId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterEntityConsumableEntity", x => new { x.CharacterListCharacterId, x.ConsumablesListConsumableId });
                    table.ForeignKey(
                        name: "FK_CharacterEntityConsumableEntity_Characters_CharacterListCharacterId",
                        column: x => x.CharacterListCharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterEntityConsumableEntity_Consumables_ConsumablesListConsumableId",
                        column: x => x.ConsumablesListConsumableId,
                        principalTable: "Consumables",
                        principalColumn: "ConsumableId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterEntityVehicleEntity",
                columns: table => new
                {
                    CharacterListCharacterId = table.Column<int>(type: "int", nullable: false),
                    VehiclesListVehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterEntityVehicleEntity", x => new { x.CharacterListCharacterId, x.VehiclesListVehicleId });
                    table.ForeignKey(
                        name: "FK_CharacterEntityVehicleEntity_Characters_CharacterListCharacterId",
                        column: x => x.CharacterListCharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterEntityVehicleEntity_Vehicles_VehiclesListVehicleId",
                        column: x => x.VehiclesListVehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterEntityWeaponEntity",
                columns: table => new
                {
                    CharacterListCharacterId = table.Column<int>(type: "int", nullable: false),
                    WeaponsListWeaponId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterEntityWeaponEntity", x => new { x.CharacterListCharacterId, x.WeaponsListWeaponId });
                    table.ForeignKey(
                        name: "FK_CharacterEntityWeaponEntity_Characters_CharacterListCharacterId",
                        column: x => x.CharacterListCharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterEntityWeaponEntity_Weapons_WeaponsListWeaponId",
                        column: x => x.WeaponsListWeaponId,
                        principalTable: "Weapons",
                        principalColumn: "WeaponId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Abilities",
                columns: new[] { "AbilityId", "AbilityAttackDamage", "AbilityDamageMultipleEnemy", "AbilityDamageSingleEnemy", "AbilityDefenseIncrease", "AbilityDescription", "AbilityEffectAttack", "AbilityEffectDefenseEnhancement", "AbilityEffectHealthEnhancement", "AbilityEffectTimeLimit", "AbilityEffectType", "AbilityHasStatusEffect", "AbilityHealingAmount", "AbilityName" },
                values: new object[,]
                {
                    { 1, 0, false, false, 0, "Invisibility, considered to be the supreme form of camouflage, as it does not reveal to the viewer any kind of vital \nsigns, visual effects, or any frequencies of the electromagnetic spectrum detectable to the human eye, instead making \nuse of radio, infrared or ultraviolet wavelengths.", false, false, false, "30 Seconds", "Physical Status Effect", true, 0, "Invisibility" },
                    { 2, 0, false, false, 0, "Restores a portion of your health.", false, false, true, "", "Healing Ability", false, 20, "Rejuvenation" },
                    { 3, 35, false, false, 0, "A seven-hit skill that consists of various slashes, several full circle spins and a backwards somersault.", true, false, false, "", "Sword Attack Ability", false, 0, "Deadly Sins" },
                    { 4, 0, false, false, 100, "A defence skill that increases the player's Defence for a single second to such an extent that their entire \nbody becomes harder than a set of full plate armour. Activation requires the player to be unarmed and only \nwearing non-metallic armour.", false, true, false, "", "Defensive Ability", false, 0, "Haganeri" }
                });

            migrationBuilder.InsertData(
                table: "Armours",
                columns: new[] { "ArmourId", "ArmourDescription", "ArmourIncreasesHealth", "ArmourIncreasesRangedAttacks", "ArmourIncreasesSwordAttacks", "ArmourName", "ArmourProvidesDefense", "IncreasedDefenseAmount", "IncreasedHealthAmount", "IncreasedRangeAttackDamageAmount", "IncreasedSwordDamageAmount" },
                values: new object[,]
                {
                    { 1, "A suit of armor made from the scales of a dragon, offering excellent protection against fire and other elemental attacks.", true, false, false, "Dragon Scale Mail", true, 15, 5, 0, 0 },
                    { 2, "Lightweight and finely crafted armor of the elves, known for its flexibility and grace.", false, true, true, "Elven Chainmail", false, 0, 0, 10, 5 },
                    { 3, "An ornate and majestic suit of armor that grants the wearer resistance to fire damage and the ability \nto rise from the ashes once per day.", true, false, false, "Plate Armor of the Phoenix", true, 35, 100, 0, 0 },
                    { 4, "A dark and stealthy cloak that shrouds the wearer in shadows, making them harder to detect.", false, false, false, "Shadow Cloak", true, 35, 0, 0, 0 },
                    { 5, "A set of dark and silent attire, designed for stealthy assassins, allowing them to move undetected.", false, true, false, "Assassin's Shadow Garb", true, 55, 0, 25, 0 },
                    { 6, "The regal attire of a powerful archmage, granting immense magical prowess and defenses.", false, true, true, "Archmage's Regalia", false, 0, 0, 25, 25 },
                    { 7, "Enigmatic robes that empower warlocks with eldritch magic and otherworldly abilities.", false, true, false, "Warlock's Eldritch Vestments", true, 35, 0, 25, 0 },
                    { 8, "A lightweight, silvery chainmail made from mithril, providing excellent protection without hindering mobility.", false, false, false, "Mithril Chain", true, 40, 0, 0, 0 },
                    { 9, "Crafted from the hide of a kraken, this armor provides resistance to aquatic threats and great flexibility.", false, false, true, "Kraken Hide Armor", true, 25, 0, 0, 15 },
                    { 10, "A sleek and agile leather vest favored by rogues and thieves, providing ease of movement and subtlety.", true, true, false, "Leather Vest of the Rogue", true, 15, 15, 35, 0 },
                    { 11, "Massive and imposing armor fit for a giant, offering incredible strength and resilience.", true, false, true, "Titan's Plate", true, 40, 15, 0, 40 }
                });

            migrationBuilder.InsertData(
                table: "BodyTypes",
                columns: new[] { "BodyTypeId", "BodyTypeName" },
                values: new object[,]
                {
                    { 1, "Muscular" },
                    { 2, "Atheletic" },
                    { 3, "SlimSkinny" },
                    { 4, "Giant" },
                    { 5, "BigBoned" },
                    { 6, "SlimMuscular" }
                });

            migrationBuilder.InsertData(
                table: "CharacterClasses",
                columns: new[] { "CharacterClassId", "CharacterClassDescription", "CharacterClassName", "CharacterClassSpecialAbility", "ClassBackstoryForCharacter", "SpeacialAbilityDefenseAmount", "SpecialAbilityDamage", "SpecialAbilityDescription", "SpecialAbilityDuration", "SpecialAbilityHealingAmount", "SpecialAbilityHeals", "SpecialAbilityIsAnAttack", "SpecialAbilityProvidesDefense", "SpecialAbilityProvidesStatusEffect" },
                values: new object[,]
                {
                    { 1, "Warriors equip themselves carefully for combat and engage their enemies head-on, letting attacks glance \noff their heavy armor. They use diverse combat tactics and a wide variety of weapon types to protect \ntheir more vulnerable allies. Warriors must carefully master their rage, the power behind their strongest \nattacks in order to maximize their effectiveness in combat.", "Warrior", "Rage", "You hail from a long line of noble knights sworn to protect the kingdom. Trained in the art of combat \nfrom a young age, you became a renowned warrior and commander of the royal army. Beneath your stoic \nexterior lies a burning desire to uncover the truth about a dark prophecy that foretells the return of \nan ancient evil. As the kingdom teeters on the brink of chaos, you decide to take up the sword, determined \nto fulfill the family's oath and vanquish the looming threat.", 0, 55, "As warriors deal or take damage, their rage grows, allowing them to deliver truly crushing attacks in the heat of battle.", "25 seconds", 0, false, true, false, false },
                    { 2, "Hunters battle their foes at a distance or up close, commanding their pets to attack while they nock their arrows, \nfire their guns, or ready their polearms. Though their weapons are effective at short and long ranges, hunters are \nalso highly mobile. They can evade or restrain their foes to control the arena of battle", "Hunter", "Tamer of the Wilds", " You have become a skilled hunter, hailing from the Elven Woodlands. The connection you have with the natural world \nand mastery of archery have made you\na renowned protector of the forest. You joins the other heroes, using your keen senses to detect the malevolent forces\nthreatening the realm. This is not only a quest to safeguard the homeland but also to restore the balance of nature.", 0, 25, "Hunters tame the beasts of the wild, and those beasts serve in return by assaulting their enemies and shielding them from harm.", "45 seconds", 0, false, true, false, false },
                    { 3, "Rogues often initiate combat with a surprise attack from the shadows, leading with vicious melee strikes.\nWhen in protracted battles, they utilize a successive combination of carefully chosen attacks to soften the \nenemy up for a killing blow. Rogues must take special care when selecting targets so that their combo attacks \nare not wasted, and they must be conscious of when to hide or flee if a battle turns against them.", "Rogue", "Stealth Attack", " You grew up an orphan on the unforgiving streets of the shadowy city of Rogarth. Your life of \npetty theft and cunning escapes changed when you discovered a cryptic map, hinting at the existence of an\nartifact that could shift the balance of power in the kingdom. Your past as a rogue makes you an invaluable  \nasset in infiltrating dangerous territories, and you are driven to find the artifact and secure the future.", 0, 30, "Rogues sneak about the battlefield, hiding from enemies and delivering surprise attacks to the unwary when opportunity arises.", "20 seconds", 0, false, true, false, true },
                    { 4, "Mages demolish their foes with arcane incantations. Although they wield powerful offensive spells, mages are \nfragile and lightly armored, making them particularly vulnerable to close-range attacks. Wise mages make \ncareful use of their spells to keep their foes at a distance or hold them in place.", "Mage", "Elemental Nova Blast", " You have becoma a gifted mage, spending your youth studying the arcane arts in the Tower of Mysteries. \nYou now possess a unique ability to see glimpses of the future through magic. The visions reveal an imminent \ncataclysm that threatens to plunge the world into darkness. To avert this fate, you must harness your powers \nand unite with other heroes to unlock the secrets hidden within ancient artifacts, preventing the oncoming disaster.", 0, 40, "By calling upon sheets of ice, columns of flame, and waves of arcane power, mages can effectively \nattack multiple foes at the same time.", "", 0, false, true, false, false },
                    { 5, "Death Knights engage their foes up-close, supplementing swings of their weapons with dark magic that renders \nenemies vulnerable or damages them with unholy power. They drag foes into one-on-one conflicts, compelling \nthem to focus their attacks away from weaker companions. To prevent their enemies from fleeing their grasp, \ndeath knights must remain mindful of the power they call forth from runes, and pace their attacks appropriately.", "Death Knight", "RuneForged Starburst Stream", "You were once a valiant knight, but corruption took hold when you were raised from the dead as a death knight by a malevolent necromancer.\ntormented by your past deeds, you now seek redemption. Using your unholy powers are harnessing them for a noble cause:\nto vanquish the darkness you once served. Your presence serves as a constant reminder of the thin line between light and shadow.", 0, 45, "Death knight runeblades are empowered with dark magic; they can expend the power of their runes for vicious attacks.", "", 0, false, true, false, false },
                    { 6, "Paladins stand directly in front of their enemies, relying on heavy armor and healing in order to survive incoming \nattacks. Whether with massive shields or crushing two-handed weapons, Paladins are able to keep claws and swords from \ntheir weaker fellows or they use healing magic to ensure that they remain on their feet.", "Paladin", "Healing Nova Blessing", "A Dawnbringer, a devoted paladin of a divine order, you set out on a quest with a sacred purpose.\nYour unwavering faith is guided by visions of an ancient prophecy, which you believes holds the key to thwarting the ancient evil.\nArmed with holy magic and a deep sense of duty, You represent the light's beacon in the darkest of times.", 0, 0, "Paladins potent healing abilities can ensure that they and their allies remain in fighting shape.", "", 25, true, false, false, false },
                    { 7, "Masters of mechanical mayhem, engineers love to tinker with explosives, elixirs, and all manner of hazardous gadgets. \nThey support their allies with alchemic weaponry, deploy ingenious inventions, or lay waste to foes with a wide array \nof mines, bombs, and grenades.", "Engineer", "Rapid Turret Deployment", " You have become a brilliant engineer, dedicating your life to inventing ingenious contraptions. The mysterious artifacts \ndiscovered in the ruins of the acients reveal their dark secrets to you. As an inventor, your knowledge \nof machinery and gadgets makes you a vital ally in deciphering the ancient devices that hold the power to \navert the impending catastrophe.", 0, 30, "An engineer constructs turrets to help defend and control an area. These devices can pound the ground to damage enemies, \ndisperse healing mist to aid allies, fire off rockets, and more.", "20 seconds", 0, false, true, false, false },
                    { 8, "Practitioners of the dark arts, necromancers summon minions, wield the power of ritual, and heal themselves with \nblood magic. Necromancers feed on life force, which they can leverage offensively or use to delay their own demise.", "Necromancer", "Life Force Drain", "You have been an outcast, shunned for the mastery over the dark arts of necromancy. Your affinity for \ncommunicating with the spirits of the deceased led you to uncover an ancient curse that has bound restless souls\nto the world. Your quest is to break the curse, not only to gain acceptance among the living but also to liberate the \n tormented spirits. In the course of the journey, you cross paths with other heroes, forming an unlikely alliance \nto combat the common threat.", 0, 15, "Life force is a special type of energy that necromancers draw from their enemies. Once theyve collected enough \nlife force, necromancers can activate their Death Shroud, entering a spirit form. Life force can be gathered \nfrom certain weapon attacks and especially from deaths that happen near the necromancer.", "20 seconds", 30, true, true, false, false }
                });

            migrationBuilder.InsertData(
                table: "Consumables",
                columns: new[] { "ConsumableId", "ConsumableAttackIncreaseAmount", "ConsumableDamageToEnemy", "ConsumableDefenseIncreaseAmount", "ConsumableDescription", "ConsumableDoesDamageToEnemy", "ConsumableEffect", "ConsumableHealthIncreaseAmount", "ConsumableIncreaseAttack", "ConsumableIncreaseDefense", "ConsumableIncreaseHealth", "ConsumableName" },
                values: new object[,]
                {
                    { 1, 0, "", 0, "A magical potion that restores a portion of your health.", false, "Restores 50 health points.", 50, false, false, true, "Health Potion" },
                    { 2, 0, "", 20, "A potent elixir that temporarily enhances your defensive capabilities.", false, "Increases your defense by 20% for 3 minutes.", 0, false, true, false, "Elixir of Protection" },
                    { 3, 30, "", 15, "A strong potion that grants you temporary, furious strength in battle.", false, "Increases your attack damage by 30% for 2 minutes but decreases defense by 15%.", 0, true, true, false, "Berserker's Brew" },
                    { 4, 30, "Paralyze Enemy for 15 Seconds", 0, "A mystical stone with the petrifying power of the Gorgon.", true, "Can be used to temporarily paralyze or petrify enemies.", 0, false, false, false, "Gorgon's Gaze Stone" },
                    { 5, 0, "Paralyze Enemy for 15 Seconds", 50, " A luminous elixir that temporarily creates a protective energy shield.", false, "Grants a temporary energy shield that reflects incoming projectiles.", 0, false, true, false, "Mirror Shield Elixir" },
                    { 6, 0, "", 0, "An ancient scroll with the power to instantly teleport \nthe user to a previously visited location.", false, "Teleports you to a known location on the map.", 0, false, false, false, "Scroll of Teleportation" },
                    { 7, 0, "", 100, "A rare and delicious fruit said to grant immortality in mythology.", false, "Fully restores health and grants temporary invincibility.", 100, false, true, true, "Ambrosia Fruit" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "DateCreated", "DateModified", "GameDescription", "GameName" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2023, 10, 26, 9, 26, 21, 627, DateTimeKind.Unspecified).AddTicks(7230), new TimeSpan(0, -4, 0, 0, 0)), null, "In a realm where magic and might coexist, the land teeters on the precipice of darkness.\nUnlikely heros must rise up, each from vastly different backgrounds, to embark on a journey\nthat will determine the fate of their world. These four heroes are on separate paths, yet the \nechoes of their destinies are inextricably linked. As they come together, they will unlock the secrets \nof ancient artifacts, face unspeakable evils, and unite against a malevolent force that threatens to plunge \nthe world into darkness. Welcome to a world of magic, valor, cunning, and the unknown. The fate of the realm rests \nin your hands. Will you rise to the occasion and uncover the truth behind the Rise of the Ancients", "Into the Heart of Darkness" });

            migrationBuilder.InsertData(
                table: "HairColors",
                columns: new[] { "HairColorId", "HairColorName" },
                values: new object[,]
                {
                    { 1, "Red" },
                    { 2, "Blonde" },
                    { 3, "Silver" },
                    { 4, "Pink" },
                    { 5, "Purple" },
                    { 6, "Orange" },
                    { 7, "Blue" },
                    { 8, "Indigo" },
                    { 9, "Rainbow" },
                    { 10, "AquaMarine" },
                    { 11, "Teal" },
                    { 12, "Green" },
                    { 13, "Black" },
                    { 14, "Brown" },
                    { 15, "White" }
                });

            migrationBuilder.InsertData(
                table: "HairStyles",
                columns: new[] { "HairStyleId", "HairStyleName" },
                values: new object[,]
                {
                    { 1, "Long Hair" },
                    { 2, "Karen's Hair Style" },
                    { 3, "Short Hair" },
                    { 4, "Long Flowing Locks" },
                    { 5, "Braided Warrior's Tresses" },
                    { 6, "Windswept Curls" },
                    { 7, "Elven Pointed Braid" },
                    { 8, "Shaved Sides with Top Knot" },
                    { 9, "Sorceress's Long Braid" },
                    { 10, "Half-Shaved, Half-Long" },
                    { 11, "Pirate's Dreadlocks with Beads" },
                    { 12, "Spiky Anime Style" },
                    { 13, "Bald and Tattooed" },
                    { 14, "Braided Beard with Rings" },
                    { 15, "Mohawk with Tribal Tattoos" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "VehicleAbility", "VehicleAttackDamage", "VehicleDescription", "VehicleHealth", "VehicleName", "VehicleSpeed", "VehicleType" },
                values: new object[,]
                {
                    { 1, "Charge", 10, "A powerful warhorse trained for battle, capable of charging into enemy lines.", 100.0, "Warhorse", 60.0, "Mount" },
                    { 2, "Aerial Maneuverability", 30, "A majestic airship that soars through the skies, offering great mobility and firepower.", 300.0, "Airship", 120.0, "Flying Vehicle" },
                    { 3, "Heavy Armor", 50, "A massive mechanical walker armed with heavy artillery, capable of withstanding immense damage.", 500.0, "Mechanical Walker", 40.0, "Mechanical" },
                    { 4, "Crunch", 75, "A massive, fearsome wolf that serves as a mount for those brave enough to tame it. Known for its \nspeed and strength, it's a formidable ally in battle.", 250.0, "DireWolf Mount", 35.0, "Mount" },
                    { 5, "Crunch", 25, " A graceful and magical mount used by the elves, capable of running on water and through dense forests with ease.", 250.0, "Elven Leafstrider", 55.0, "Mount" },
                    { 6, "Crunch", 25, " A majestic creature with the body of a lion and wings of an eagle, perfect for aerial combat and reconnaissance.", 200.0, "BuckBeak The Griffon", 65.0, " Flying Mount" }
                });

            migrationBuilder.InsertData(
                table: "Weapons",
                columns: new[] { "WeaponId", "RangedWeaponDistance", "WeaponDamageAmount", "WeaponDescription", "WeaponGeneratesSplashDamage", "WeaponIsAMeleeWeapon", "WeaponIsARangedWeapon", "WeaponName", "WeaponSplashDamageAmount", "WeaponType" },
                values: new object[,]
                {
                    { 1, "20 meters", 35, "A radiant bow blessed by celestial beings, firing arrows of divine light that can smite darkness and heal allies.", true, false, true, "Celestial Bow of Radiance", 10, "Bow and Arrow" },
                    { 2, "", 35, " A concealed dagger used by rogues for stealthy assassinations, designed to leave no trace behind.", false, true, false, "Rogue's Dagger of Shadows", 0, "Dagger" },
                    { 3, "20 meters", 40, " A staff that channels the power of dragons, allowing the caster to unleash devastating fire spells.", true, false, true, "Dragonfire Staff", 15, "Mage Staff" },
                    { 4, "", 65, " A razor-sharp sword that can sever heads with a single swing, a weapon favored by those seeking decapitating strikes.", false, true, false, "Vorpal Blade", 0, "Katana" },
                    { 5, "", 45, "A massive and sturdy warhammer forged in dwarven forges, able to crush opponents and breach defenses.", true, true, false, "Dwarven Warhammer", 15, "WarHammer" },
                    { 6, "", 50, "A menacing scythe associated with necromancers, capable of harvesting souls and controlling the undead.", false, true, false, "Necromancer's Scythe", 0, "Scythe" },
                    { 7, "5 meters", 30, "A cane with concealed tricks and traps, used by jesters and pranksters for both entertainment and subterfuge.", true, true, true, "Jester's Trickster Cane", 15, "Sword" },
                    { 8, "35 meters", 45, "A cane with concealed tricks and traps, used by jesters and pranksters for both entertainment and subterfuge.", true, false, true, "Elven Longbow", 15, "Bow And Arrow" },
                    { 9, "35 meters", 65, "The legendary sword of King Arthur, said to be the most powerful and righteous weapon in the realm, capable of vanquishing evil.", true, true, false, "Excalibur", 20, "Sword" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbilityEntityCharacterEntity_CharacterListCharacterId",
                table: "AbilityEntityCharacterEntity",
                column: "CharacterListCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_ArmourEntityCharacterEntity_CharacterListCharacterId",
                table: "ArmourEntityCharacterEntity",
                column: "CharacterListCharacterId");

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
                name: "IX_CharacterEntityConsumableEntity_ConsumablesListConsumableId",
                table: "CharacterEntityConsumableEntity",
                column: "ConsumablesListConsumableId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterEntityVehicleEntity_VehiclesListVehicleId",
                table: "CharacterEntityVehicleEntity",
                column: "VehiclesListVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterEntityWeaponEntity_WeaponsListWeaponId",
                table: "CharacterEntityWeaponEntity",
                column: "WeaponsListWeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_BodyTypeId",
                table: "Characters",
                column: "BodyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CharacterClassId",
                table: "Characters",
                column: "CharacterClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_HairColorId",
                table: "Characters",
                column: "HairColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_HairStyleId",
                table: "Characters",
                column: "HairStyleId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_UserId",
                table: "Characters",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbilityEntityCharacterEntity");

            migrationBuilder.DropTable(
                name: "ArmourEntityCharacterEntity");

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
                name: "CharacterEntityConsumableEntity");

            migrationBuilder.DropTable(
                name: "CharacterEntityVehicleEntity");

            migrationBuilder.DropTable(
                name: "CharacterEntityWeaponEntity");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Maps");

            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DropTable(
                name: "Armours");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Consumables");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "BodyTypes");

            migrationBuilder.DropTable(
                name: "CharacterClasses");

            migrationBuilder.DropTable(
                name: "HairColors");

            migrationBuilder.DropTable(
                name: "HairStyles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
