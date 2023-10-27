using DnDTeamGame.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DnDTeamGame.Data;

public class ApplicationDbContext : IdentityDbContext<UserEntity, IdentityRole<int>, int>
{
    public DbSet<MapEntity> Maps { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)

        : base(options) { }


    public DbSet<GameEntity> Games { get; set; } = null!;

    public DbSet<CharacterClassEntity> CharacterClasses { get; set; } = null!;
    public DbSet<WeaponEntity> Weapons { get; set; } = null!;
    public DbSet<ConsumableEntity> Consumables { get; set; } = null!;
    public DbSet<VehicleEntity> Vehicles { get; set; } = null!;
    public DbSet<ArmourEntity> Armours { get; set; } = null!;
    public DbSet<HairStyleEntity> HairStyles { get; set; } = null!;
    public DbSet<HairColorEntity> HairColors { get; set; } = null!;
    public DbSet<AbilityEntity> Abilities { get; set; } = null!;
    public DbSet<BodyTypeEntity> BodyTypes { get; set; } = null!;
    public DbSet<CharacterEntity> Characters { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UserEntity>().ToTable("Users");
        modelBuilder.Entity<AbilityEntity>().HasData(
            new AbilityEntity
            {
                AbilityId = 1,
                AbilityName = "Invisibility",
                AbilityDescription = " Invisibility, considered to be the supreme form of camouflage, as it does not reveal to the viewer any kind of vital \n" +
                                     " signs, visual effects, or any frequencies of the electromagnetic spectrum detectable to the human eye, instead making \n" +
                                     " use of radio, infrared or ultraviolet wavelengths.",
                AbilityEffectType = " Physical Status Effect",
                AbilityEffectAttack = false,
                AbilityEffectHealthEnhancement = false,
                AbilityEffectDefenseEnhancement = false,
                AbilityHasStatusEffect = true,
                AbilityDamageSingleEnemy = false,
                AbilityDamageMultipleEnemy = false,
                AbilityAttackDamage = 0,
                AbilityHealingAmount = 0,
                AbilityDefenseIncrease = 0,
                AbilityEffectTimeLimit = "30 Seconds"
            },
            new AbilityEntity
            {
                AbilityId = 2,
                AbilityName = "Rejuvenation",
                AbilityDescription = "Restores a portion of your health.",
                AbilityEffectType = "Healing Ability",
                AbilityEffectAttack = false,
                AbilityEffectHealthEnhancement = true,
                AbilityEffectDefenseEnhancement = false,
                AbilityHasStatusEffect = false,
                AbilityDamageSingleEnemy = false,
                AbilityDamageMultipleEnemy = false,
                AbilityAttackDamage = 0,
                AbilityHealingAmount = 20,
                AbilityDefenseIncrease = 0,
                AbilityEffectTimeLimit = ""
            },

            new AbilityEntity
            {
                AbilityId = 3,
                AbilityName = "Deadly Sins",
                AbilityDescription = " A seven-hit skill that consists of various slashes, several full circle spins and a backwards somersault.",
                AbilityEffectType = " Sword Attack Ability",
                AbilityEffectAttack = true,
                AbilityEffectHealthEnhancement = false,
                AbilityEffectDefenseEnhancement = false,
                AbilityHasStatusEffect = false,
                AbilityDamageSingleEnemy = false,
                AbilityDamageMultipleEnemy = false,
                AbilityAttackDamage = 35,
                AbilityHealingAmount = 0,
                AbilityDefenseIncrease = 0,
                AbilityEffectTimeLimit = ""
            },

            new AbilityEntity
            {
                AbilityId = 4,
                AbilityName = "Haganeri",
                AbilityDescription = " A defence skill that increases the player's Defence for a single second to such an extent that their entire \n" +
                                     " body becomes harder than a set of full plate armour. Activation requires the player to be unarmed and only \n" +
                                     " wearing non-metallic armour.",
                AbilityEffectType = "Defensive Ability",
                AbilityEffectAttack = false,
                AbilityEffectHealthEnhancement = false,
                AbilityEffectDefenseEnhancement = true,
                AbilityHasStatusEffect = false,
                AbilityDamageSingleEnemy = false,
                AbilityDamageMultipleEnemy = false,
                AbilityAttackDamage = 0,
                AbilityHealingAmount = 0,
                AbilityDefenseIncrease = 100,
                AbilityEffectTimeLimit = ""
            }
            );

        modelBuilder.Entity<BodyTypeEntity>().HasData(
            new BodyTypeEntity
            {
                BodyTypeId = 1,
                BodyTypeName = "Muscular",
            },

            new BodyTypeEntity
            {
                BodyTypeId = 2,
                BodyTypeName = "Atheletic",
            },

            new BodyTypeEntity
            {
                BodyTypeId = 3,
                BodyTypeName = "SlimSkinny",
            },

            new BodyTypeEntity
            {
                BodyTypeId = 4,
                BodyTypeName = "Giant",
            },

            new BodyTypeEntity
            {
                BodyTypeId = 5,
                BodyTypeName = "BigBoned",
            },

            new BodyTypeEntity
            {
                BodyTypeId = 6,
                BodyTypeName = "SlimMuscular",
            }
        );

        modelBuilder.Entity<CharacterClassEntity>().HasData(
            new CharacterClassEntity
            {
                CharacterClassId = 1,
                CharacterClassName = "Warrior",
                CharacterClassDescription = " Warriors equip themselves carefully for combat and engage their enemies head-on, letting attacks glance \n"+
                                            " off their heavy armor. They use diverse combat tactics and a wide variety of weapon types to protect \n" + 
                                            " their more vulnerable allies. Warriors must carefully master their rage, the power behind their strongest \n" +
                                            " attacks in order to maximize their effectiveness in combat.",
                CharacterClassSpecialAbility = "Rage",
                SpecialAbilityIsAnAttack = true,
                SpecialAbilityHeals = false,
                SpecialAbilityProvidesDefense = false,
                SpecialAbilityProvidesStatusEffect = false,
                SpecialAbilityDamage = 55,
                SpecialAbilityHealingAmount = 0,
                SpeacialAbilityDefenseAmount = 0,
                SpecialAbilityDuration = "25 seconds",
                SpecialAbilityDescription = " As warriors deal or take damage, their rage grows, allowing them to deliver truly crushing attacks in the heat of battle.",
                ClassBackstoryForCharacter = " You hail from a long line of noble knights sworn to protect the kingdom. Trained in the art of combat \n" +
                                            " from a young age, you became a renowned warrior and commander of the royal army. Beneath your stoic \n" +
                                            " exterior lies a burning desire to uncover the truth about a dark prophecy that foretells the return of \n" +
                                            " an ancient evil. As the kingdom teeters on the brink of chaos, you decide to take up the sword, determined \n" +
                                            " to fulfill the family's oath and vanquish the looming threat."
            },

            new CharacterClassEntity
            {
                CharacterClassId = 2,
                CharacterClassName = "Hunter",
                CharacterClassDescription = " Hunters battle their foes at a distance or up close, commanding their pets to attack while they nock their arrows, \n" +
                                            " fire their guns, or ready their polearms. Though their weapons are effective at short and long ranges, hunters are \n" +
                                            " also highly mobile. They can evade or restrain their foes to control the arena of battle",
                CharacterClassSpecialAbility = "Tamer of the Wilds",
                SpecialAbilityIsAnAttack = true,
                SpecialAbilityHeals = false,
                SpecialAbilityProvidesDefense = false,
                SpecialAbilityProvidesStatusEffect = false,
                SpecialAbilityDamage = 25,
                SpecialAbilityHealingAmount = 0,
                SpeacialAbilityDefenseAmount = 0,
                SpecialAbilityDuration = "45 seconds",
                SpecialAbilityDescription = " Hunters tame the beasts of the wild, and those beasts serve in return by assaulting their enemies and shielding them from harm.",
                ClassBackstoryForCharacter = " You have become a skilled hunter, hailing from the Elven Woodlands. The connection you have with the natural world \n" +
                                            " and mastery of archery have made you\n" +
                                            " a renowned protector of the forest. You joins the other heroes, using your keen senses to detect the malevolent forces\n" +
                                            " threatening the realm. This is not only a quest to safeguard the homeland but also to restore the balance of nature."
            },

            new CharacterClassEntity
            {
                CharacterClassId = 3,
                CharacterClassName = "Rogue",
                CharacterClassDescription = "  Rogues often initiate combat with a surprise attack from the shadows, leading with vicious melee strikes.\n" +
                                            "  When in protracted battles, they utilize a successive combination of carefully chosen attacks to soften the \n" +
                                            "  enemy up for a killing blow. Rogues must take special care when selecting targets so that their combo attacks \n"+
                                            "  are not wasted, and they must be conscious of when to hide or flee if a battle turns against them.",
                CharacterClassSpecialAbility = "Stealth Attack",
                SpecialAbilityIsAnAttack = true,
                SpecialAbilityHeals = false,
                SpecialAbilityProvidesDefense = false,
                SpecialAbilityProvidesStatusEffect = true,
                SpecialAbilityDamage = 30,
                SpecialAbilityHealingAmount = 0,
                SpeacialAbilityDefenseAmount = 0,
                SpecialAbilityDuration = "20 seconds",
                SpecialAbilityDescription = " Rogues sneak about the battlefield, hiding from enemies and delivering surprise attacks to the unwary when opportunity arises.",
                ClassBackstoryForCharacter = " You grew up an orphan on the unforgiving streets of the shadowy city of Rogarth. Your life of \n" +
                                            " petty theft and cunning escapes changed when you discovered a cryptic map, hinting at the existence of an\n" +
                                            " artifact that could shift the balance of power in the kingdom. Your past as a rogue makes you an invaluable  \n" +
                                            " asset in infiltrating dangerous territories, and you are driven to find the artifact and secure the future."
            },

            new CharacterClassEntity
            {
                CharacterClassId = 4,
                CharacterClassName = "Mage",
                CharacterClassDescription = "  Mages demolish their foes with arcane incantations. Although they wield powerful offensive spells, mages are \n" +
                                            "  fragile and lightly armored, making them particularly vulnerable to close-range attacks. Wise mages make \n" +
                                            "  careful use of their spells to keep their foes at a distance or hold them in place.",
                CharacterClassSpecialAbility = "Elemental Nova Blast",
                SpecialAbilityIsAnAttack = true,
                SpecialAbilityHeals = false,
                SpecialAbilityProvidesDefense = false,
                SpecialAbilityProvidesStatusEffect = false,
                SpecialAbilityDamage = 40,
                SpecialAbilityHealingAmount = 0,
                SpeacialAbilityDefenseAmount = 0,
                SpecialAbilityDuration = "",
                SpecialAbilityDescription = "  By calling upon sheets of ice, columns of flame, and waves of arcane power, mages can effectively \n" +
                                            "  attack multiple foes at the same time.",
                ClassBackstoryForCharacter = "  You have becoma a gifted mage, spending your youth studying the arcane arts in the Tower of Mysteries. \n" +
                                            "  You now possess a unique ability to see glimpses of the future through magic. The visions reveal an imminent \n" +
                                            "  cataclysm that threatens to plunge the world into darkness. To avert this fate, you must harness your powers \n" +
                                            "  and unite with other heroes to unlock the secrets hidden within ancient artifacts, preventing the oncoming disaster."
            },

            new CharacterClassEntity
            {
                CharacterClassId = 5,
                CharacterClassName = "Death Knight",
                CharacterClassDescription = "  Death Knights engage their foes up-close, supplementing swings of their weapons with dark magic that renders \n" +
                                            "  enemies vulnerable or damages them with unholy power. They drag foes into one-on-one conflicts, compelling \n" +
                                            "  them to focus their attacks away from weaker companions. To prevent their enemies from fleeing their grasp, \n" +
                                            "  death knights must remain mindful of the power they call forth from runes, and pace their attacks appropriately.",
                CharacterClassSpecialAbility = "RuneForged Starburst Stream",
                SpecialAbilityIsAnAttack = true,
                SpecialAbilityHeals = false,
                SpecialAbilityProvidesDefense = false,
                SpecialAbilityProvidesStatusEffect = false,
                SpecialAbilityDamage = 45,
                SpecialAbilityHealingAmount = 0,
                SpeacialAbilityDefenseAmount = 0,
                SpecialAbilityDuration = "",
                SpecialAbilityDescription = "  Death knight runeblades are empowered with dark magic; they can expend the power of their runes for vicious attacks.",
                ClassBackstoryForCharacter = "  You were once a valiant knight, but corruption took hold when you were raised from the dead as a death knight by a malevolent necromancer.\n" +
                                            "  tormented by your past deeds, you now seek redemption. Using your unholy powers are harnessing them for a noble cause:\n" +
                                            "  to vanquish the darkness you once served. Your presence serves as a constant reminder of the thin line between light and shadow."
            },

            new CharacterClassEntity
            {
                CharacterClassId = 6,
                CharacterClassName = "Paladin",
                CharacterClassDescription = "  Paladins stand directly in front of their enemies, relying on heavy armor and healing in order to survive incoming \n" +
                                            "  attacks. Whether with massive shields or crushing two-handed weapons, Paladins are able to keep claws and swords from \n" +
                                            "  their weaker fellows or they use healing magic to ensure that they remain on their feet.",
                CharacterClassSpecialAbility = "Healing Nova Blessing",
                SpecialAbilityIsAnAttack = false,
                SpecialAbilityHeals = true,
                SpecialAbilityProvidesDefense = false,
                SpecialAbilityProvidesStatusEffect = false,
                SpecialAbilityDamage = 0,
                SpecialAbilityHealingAmount = 25,
                SpeacialAbilityDefenseAmount = 0,
                SpecialAbilityDuration = "",
                SpecialAbilityDescription = "  Paladins potent healing abilities can ensure that they and their allies remain in fighting shape.",
                ClassBackstoryForCharacter = "  A Dawnbringer, a devoted paladin of a divine order, you set out on a quest with a sacred purpose.\n" +
                                            "  Your unwavering faith is guided by visions of an ancient prophecy, which you believes holds the key to thwarting the ancient evil.\n" +
                                            "  Armed with holy magic and a deep sense of duty, You represent the light's beacon in the darkest of times."
            },

            new CharacterClassEntity
            {
                CharacterClassId = 7,
                CharacterClassName = "Engineer",
                CharacterClassDescription = "  Masters of mechanical mayhem, engineers love to tinker with explosives, elixirs, and all manner of hazardous gadgets. \n" +
                                            "  They support their allies with alchemic weaponry, deploy ingenious inventions, or lay waste to foes with a wide array \n" +
                                            "  of mines, bombs, and grenades.",
                CharacterClassSpecialAbility = "Rapid Turret Deployment",
                SpecialAbilityIsAnAttack = true,
                SpecialAbilityHeals = false,
                SpecialAbilityProvidesDefense = false,
                SpecialAbilityProvidesStatusEffect = false,
                SpecialAbilityDamage = 30,
                SpecialAbilityHealingAmount = 0,
                SpeacialAbilityDefenseAmount = 0,
                SpecialAbilityDuration = "20 seconds",
                SpecialAbilityDescription = "  An engineer constructs turrets to help defend and control an area. These devices can pound the ground to damage enemies, \n" +
                                            "  disperse healing mist to aid allies, fire off rockets, and more.",
                ClassBackstoryForCharacter = "  You have become a brilliant engineer, dedicating your life to inventing ingenious contraptions. The mysterious artifacts \n" +
                                            "  discovered in the ruins of the acients reveal their dark secrets to you. As an inventor, your knowledge \n" +
                                            "  of machinery and gadgets makes you a vital ally in deciphering the ancient devices that hold the power to \n" +
                                            "  avert the impending catastrophe."
            },
 
            new CharacterClassEntity
            {
                CharacterClassId = 8,
                CharacterClassName = "Necromancer",
                CharacterClassDescription = " Practitioners of the dark arts, necromancers summon minions, wield the power of ritual, and heal themselves with \n" +
                                            " blood magic. Necromancers feed on life force, which they can leverage offensively or use to delay their own demise.",
                CharacterClassSpecialAbility = "Life Force Drain",
                SpecialAbilityIsAnAttack = true,
                SpecialAbilityHeals = true,
                SpecialAbilityProvidesDefense = false,
                SpecialAbilityProvidesStatusEffect = false,
                SpecialAbilityDamage = 15,
                SpecialAbilityHealingAmount = 30,
                SpeacialAbilityDefenseAmount = 0,
                SpecialAbilityDuration = "20 seconds",
                SpecialAbilityDescription = "  Life force is a special type of energy that necromancers draw from their enemies. Once theyve collected enough \n" +
                                            "  life force, necromancers can activate their Death Shroud, entering a spirit form. Life force can be gathered \n" +
                                            "  from certain weapon attacks and especially from deaths that happen near the necromancer.",
                ClassBackstoryForCharacter = "  You have been an outcast, shunned for the mastery over the dark arts of necromancy. Your affinity for \n" +
                                            "  communicating with the spirits of the deceased led you to uncover an ancient curse that has bound restless souls\n" +
                                            "  to the world. Your quest is to break the curse, not only to gain acceptance among the living but also to liberate the \n" +
                                            "  tormented spirits. In the course of the journey, you cross paths with other heroes, forming an unlikely alliance \n" +
                                            "  to combat the common threat."
            }
        );

        modelBuilder.Entity<ArmourEntity>().HasData(
            new ArmourEntity
            {
                ArmourId = 1,
                ArmourName = " Dragon Scale Mail",
                ArmourDescription = " A suit of armor made from the scales of a dragon, offering excellent protection against fire and other elemental attacks.",
                ArmourProvidesDefense = true,
                ArmourIncreasesHealth = true,
                ArmourIncreasesSwordAttacks = false,
                ArmourIncreasesRangedAttacks = false,
                IncreasedHealthAmount = 5,
                IncreasedSwordDamageAmount = 0,
                IncreasedRangeAttackDamageAmount = 0,
                IncreasedDefenseAmount = 15
            },

            new ArmourEntity
            {
                ArmourId = 2,
                ArmourName = " Elven Chainmail",

                ArmourDescription = " Lightweight and finely crafted armor of the elves, known for its flexibility and grace.",

                ArmourProvidesDefense = false,
                ArmourIncreasesHealth = false,
                ArmourIncreasesSwordAttacks = true,
                ArmourIncreasesRangedAttacks = true,
                IncreasedHealthAmount = 0,
                IncreasedSwordDamageAmount = 5,
                IncreasedRangeAttackDamageAmount = 10,
                IncreasedDefenseAmount = 0
            },

            new ArmourEntity
            {
                ArmourId = 3,
                ArmourName = "Plate Armor of the Phoenix",
                ArmourDescription = " An ornate and majestic suit of armor that grants the wearer resistance to fire damage and the ability \n" +
                                    " to rise from the ashes once per day.",
                ArmourProvidesDefense = true,
                ArmourIncreasesHealth = true,
                ArmourIncreasesSwordAttacks = false,
                ArmourIncreasesRangedAttacks = false,
                IncreasedHealthAmount = 100,
                IncreasedSwordDamageAmount = 0,
                IncreasedRangeAttackDamageAmount = 0,
                IncreasedDefenseAmount = 35
            },

            new ArmourEntity
            {
                ArmourId = 4,
                ArmourName = "Shadow Cloak",
                ArmourDescription = " A dark and stealthy cloak that shrouds the wearer in shadows, making them harder to detect.",
                ArmourProvidesDefense = true,
                ArmourIncreasesHealth = false,
                ArmourIncreasesSwordAttacks = false,
                ArmourIncreasesRangedAttacks = false,
                IncreasedHealthAmount = 0,
                IncreasedSwordDamageAmount = 0,
                IncreasedRangeAttackDamageAmount = 0,
                IncreasedDefenseAmount = 35
            },

            new ArmourEntity
            {
                ArmourId = 5,
                ArmourName = "Assassin's Shadow Garb",
                ArmourDescription = "A set of dark and silent attire, designed for stealthy assassins, allowing them to move undetected.",
                ArmourProvidesDefense = true,
                ArmourIncreasesHealth = false,
                ArmourIncreasesSwordAttacks = false,
                ArmourIncreasesRangedAttacks = true,
                IncreasedHealthAmount = 0,
                IncreasedSwordDamageAmount = 0,
                IncreasedRangeAttackDamageAmount = 25,
                IncreasedDefenseAmount = 55
            },

            new ArmourEntity
            {
                ArmourId = 6,
                ArmourName = "Archmage's Regalia",
                ArmourDescription = "The regal attire of a powerful archmage, granting immense magical prowess and defenses.",
                ArmourProvidesDefense = false,
                ArmourIncreasesHealth = false,
                ArmourIncreasesSwordAttacks = true,
                ArmourIncreasesRangedAttacks = true,
                IncreasedHealthAmount = 0,
                IncreasedSwordDamageAmount = 25,
                IncreasedRangeAttackDamageAmount = 25,
                IncreasedDefenseAmount = 0
            },

            new ArmourEntity
            {
                ArmourId = 7,
                ArmourName = "Warlock's Eldritch Vestments",
                ArmourDescription = " Enigmatic robes that empower warlocks with eldritch magic and otherworldly abilities.",
                ArmourProvidesDefense = true,
                ArmourIncreasesHealth = false,
                ArmourIncreasesSwordAttacks = false,
                ArmourIncreasesRangedAttacks = true,
                IncreasedHealthAmount = 0,
                IncreasedSwordDamageAmount = 0,
                IncreasedRangeAttackDamageAmount = 25,
                IncreasedDefenseAmount = 35
            },

            new ArmourEntity
            {
                ArmourId = 8,
                ArmourName = " Mithril Chain",
                ArmourDescription = " A lightweight, silvery chainmail made from mithril, providing excellent protection without hindering mobility.",
                ArmourProvidesDefense = true,
                ArmourIncreasesHealth = false,
                ArmourIncreasesSwordAttacks = false,
                ArmourIncreasesRangedAttacks = false,
                IncreasedHealthAmount = 0,
                IncreasedSwordDamageAmount = 0,
                IncreasedRangeAttackDamageAmount = 0,
                IncreasedDefenseAmount = 40
            },

            new ArmourEntity
            {
                ArmourId = 9,
                ArmourName = " Kraken Hide Armor",
                ArmourDescription = " Crafted from the hide of a kraken, this armor provides resistance to aquatic threats and great flexibility.",
                ArmourProvidesDefense = true,
                ArmourIncreasesHealth = false,
                ArmourIncreasesSwordAttacks = true,
                ArmourIncreasesRangedAttacks = false,
                IncreasedHealthAmount = 0,
                IncreasedSwordDamageAmount = 15,
                IncreasedRangeAttackDamageAmount = 0,
                IncreasedDefenseAmount = 25
            },

            new ArmourEntity
            {
                ArmourId = 10,
                ArmourName = " Leather Vest of the Rogue",
                ArmourDescription = " A sleek and agile leather vest favored by rogues and thieves, providing ease of movement and subtlety.",
                ArmourProvidesDefense = true,
                ArmourIncreasesHealth = true,
                ArmourIncreasesSwordAttacks = false,
                ArmourIncreasesRangedAttacks = true,
                IncreasedHealthAmount = 15,
                IncreasedSwordDamageAmount = 0,
                IncreasedRangeAttackDamageAmount = 35,
                IncreasedDefenseAmount = 15
            },

            new ArmourEntity
            {
                ArmourId = 11,
                ArmourName = "Titan's Plate",
                ArmourDescription = "Massive and imposing armor fit for a giant, offering incredible strength and resilience.",
                ArmourProvidesDefense = true,
                ArmourIncreasesHealth = true,
                ArmourIncreasesSwordAttacks = true,
                ArmourIncreasesRangedAttacks = false,
                IncreasedHealthAmount = 15,
                IncreasedSwordDamageAmount = 40,
                IncreasedRangeAttackDamageAmount = 0,
                IncreasedDefenseAmount = 40
            }

        );

        modelBuilder.Entity<ConsumableEntity>().HasData(
            new ConsumableEntity
            {
                ConsumableId = 1,
                ConsumableName = "Health Potion",
                // Quantity = 3.0,
                ConsumableDescription = " A magical potion that restores a portion of your health.",
                ConsumableEffect = " Restores 50 health points.",
                ConsumableIncreaseHealth = true,
                ConsumableIncreaseDefense = false,
                ConsumableIncreaseAttack = false,
                ConsumableDoesDamageToEnemy = false,
                ConsumableDamageToEnemy = "",
                ConsumableHealthIncreaseAmount = 50,
                ConsumableDefenseIncreaseAmount = 0,
                ConsumableAttackIncreaseAmount = 0
            },

            new ConsumableEntity
            {
                ConsumableId = 2,
                ConsumableName = "Elixir of Protection",
                // Quantity = 2.5,
                ConsumableDescription = "  A potent elixir that temporarily enhances your defensive capabilities.",
                ConsumableEffect = "  Increases your defense by 20% for 3 minutes.",
                ConsumableIncreaseHealth = false,
                ConsumableIncreaseDefense = true,
                ConsumableIncreaseAttack = false,
                ConsumableDoesDamageToEnemy = false,
                ConsumableDamageToEnemy = "",
                ConsumableHealthIncreaseAmount = 0,
                ConsumableDefenseIncreaseAmount = 20,
                ConsumableAttackIncreaseAmount = 0
            },

            new ConsumableEntity
            {
                ConsumableId = 3,
                ConsumableName = "Berserker's Brew",
                // Quantity = 1.0,
                ConsumableDescription = "  A strong potion that grants you temporary, furious strength in battle.",
                ConsumableEffect = "  Increases your attack damage by 30% for 2 minutes but decreases defense by 15%.",
                ConsumableIncreaseHealth = false,
                ConsumableIncreaseDefense = true,
                ConsumableIncreaseAttack = true,
                ConsumableDoesDamageToEnemy = false,
                ConsumableDamageToEnemy = "",
                ConsumableHealthIncreaseAmount = 0,
                ConsumableDefenseIncreaseAmount = 15,
                ConsumableAttackIncreaseAmount = 30
            },

            new ConsumableEntity
            {
                ConsumableId = 4,
                ConsumableName = "Gorgon's Gaze Stone",
                // Quantity = 1.0,
                ConsumableDescription = "  A mystical stone with the petrifying power of the Gorgon.",
                ConsumableEffect = "  Can be used to temporarily paralyze or petrify enemies.",
                ConsumableIncreaseHealth = false,
                ConsumableIncreaseDefense = false,
                ConsumableIncreaseAttack = false,
                ConsumableDoesDamageToEnemy = true,
                ConsumableDamageToEnemy = "  Paralyze Enemy for 15 Seconds",
                ConsumableHealthIncreaseAmount = 0,
                ConsumableDefenseIncreaseAmount = 0,
                ConsumableAttackIncreaseAmount = 30
            },

            new ConsumableEntity
            {
                ConsumableId = 5,
                ConsumableName = "Mirror Shield Elixir",
                // Quantity = 1.0,
                ConsumableDescription = " A luminous elixir that temporarily creates a protective energy shield.",
                ConsumableEffect = "  Grants a temporary energy shield that reflects incoming projectiles.",
                ConsumableIncreaseHealth = false,
                ConsumableIncreaseDefense = true,
                ConsumableIncreaseAttack = false,
                ConsumableDoesDamageToEnemy = false,
                ConsumableDamageToEnemy = " Paralyze Enemy for 15 Seconds",
                ConsumableHealthIncreaseAmount = 0,
                ConsumableDefenseIncreaseAmount = 50,
                ConsumableAttackIncreaseAmount = 0
            },

            new ConsumableEntity
            {
                ConsumableId = 6,
                ConsumableName = "Scroll of Teleportation",
                // Quantity = 1.0,
                ConsumableDescription = "  An ancient scroll with the power to instantly teleport \n"+
                                        "  the user to a previously visited location.",
                ConsumableEffect = "  Teleports you to a known location on the map.",
                ConsumableIncreaseHealth = false,
                ConsumableIncreaseDefense = false,
                ConsumableIncreaseAttack = false,
                ConsumableDoesDamageToEnemy = false,
                ConsumableDamageToEnemy = "",
                ConsumableHealthIncreaseAmount = 0,
                ConsumableDefenseIncreaseAmount = 0,
                ConsumableAttackIncreaseAmount = 0
            },

            new ConsumableEntity
            {
                ConsumableId = 7,
                ConsumableName = "Ambrosia Fruit",
                // Quantity = 1.0,
                ConsumableDescription = "  A rare and delicious fruit said to grant immortality in mythology.",
                ConsumableEffect = "  Fully restores health and grants temporary invincibility.",
                ConsumableIncreaseHealth = true,
                ConsumableIncreaseDefense = true,
                ConsumableIncreaseAttack = false,
                ConsumableDoesDamageToEnemy = false,
                ConsumableDamageToEnemy = "",
                ConsumableHealthIncreaseAmount = 100,
                ConsumableDefenseIncreaseAmount = 100,
                ConsumableAttackIncreaseAmount = 0
            }

        );

        modelBuilder.Entity<VehicleEntity>().HasData(
            new VehicleEntity
            {
                VehicleId = 1,
                VehicleName = "Warhorse",
                VehicleSpeed = 60.0,
                VehicleAbility = "Charge",
                VehicleType = "Mount",
                VehicleDescription = " A powerful warhorse trained for battle, capable of charging into enemy lines.",
                VehicleAttackDamage = 10,
                VehicleHealth = 100
            },
            new VehicleEntity
            {
                VehicleId = 2,
                VehicleName = "Airship",
                VehicleSpeed = 120.0,
                VehicleAbility = "Aerial Maneuverability",
                VehicleType = "Flying Vehicle",
                VehicleDescription = " A majestic airship that soars through the skies, offering great mobility and firepower.",
                VehicleAttackDamage = 30,
                VehicleHealth = 300
            },
            new VehicleEntity
            {
                VehicleId = 3,
                VehicleName = "Mechanical Walker",
                VehicleSpeed = 40.0,
                VehicleAbility = "Heavy Armor",
                VehicleType = "Mechanical",
                VehicleDescription = " A massive mechanical walker armed with heavy artillery, capable of withstanding immense damage.",
                VehicleAttackDamage = 50,
                VehicleHealth = 500
            },

            new VehicleEntity
            {
                VehicleId = 4,
                VehicleName = "DireWolf Mount",
                VehicleSpeed = 35.0,
                VehicleAbility = "Crunch",
                VehicleType = "Mount",
                VehicleDescription = " A massive, fearsome wolf that serves as a mount for those brave enough to tame it. Known for its \n" +
                                    " speed and strength, it's a formidable ally in battle.",
                VehicleAttackDamage = 75,
                VehicleHealth = 250
            },

            new VehicleEntity
            {
                VehicleId = 5,
                VehicleName = "Elven Leafstrider",
                VehicleSpeed = 55.0,
                VehicleAbility = "Crunch",
                VehicleType = "Mount",
                VehicleDescription = " A graceful and magical mount used by the elves, capable of running on water and through dense forests with ease.",
                VehicleAttackDamage = 25,
                VehicleHealth = 250
            },

            new VehicleEntity
            {
                VehicleId = 6,
                VehicleName = "BuckBeak The Griffon",
                VehicleSpeed = 65.0,
                VehicleAbility = "Crunch",
                VehicleType = " Flying Mount",
                VehicleDescription = " A majestic creature with the body of a lion and wings of an eagle, perfect for aerial combat and reconnaissance.",
                VehicleAttackDamage = 25,
                VehicleHealth = 200
            }
        );

        modelBuilder.Entity<HairColorEntity>().HasData(
            new HairColorEntity
            {
                HairColorId = 1,
                HairColorName = "Red"
            },

            new HairColorEntity
            {
                HairColorId = 2,
                HairColorName = "Blonde"
            },

            new HairColorEntity
            {
                HairColorId = 3,
                HairColorName = "Silver"
            },

            new HairColorEntity
            {
                HairColorId = 4,
                HairColorName = "Pink"
            },

            new HairColorEntity
            {
                HairColorId = 5,
                HairColorName = "Purple"
            },

            new HairColorEntity
            {
                HairColorId = 6,
                HairColorName = "Orange"
            },

            new HairColorEntity
            {
                HairColorId = 7,
                HairColorName = "Blue"
            },

            new HairColorEntity
            {
                HairColorId = 8,
                HairColorName = "Indigo"
            },

            new HairColorEntity
            {
                HairColorId = 9,
                HairColorName = "Rainbow"
            },

            new HairColorEntity
            {
                HairColorId = 10,
                HairColorName = "AquaMarine"
            },

            new HairColorEntity
            {
                HairColorId = 11,
                HairColorName = "Teal"
            },

            new HairColorEntity
            {
                HairColorId = 12,
                HairColorName = "Green"
            },

            new HairColorEntity
            {
                HairColorId = 13,
                HairColorName = "Black"
            },

            new HairColorEntity
            {
                HairColorId = 14,
                HairColorName = "Brown"
            },

            new HairColorEntity
            {
                HairColorId = 15,
                HairColorName = "White"
            }
        );

        modelBuilder.Entity<HairStyleEntity>().HasData(
            new HairStyleEntity
            {
                HairStyleId = 1,
                HairStyleName = "Long Hair"
            },

            new HairStyleEntity
            {
                HairStyleId = 2,
                HairStyleName = "Karen's Hair Style"
            },

            new HairStyleEntity
            {
                HairStyleId = 3,
                HairStyleName = "Short Hair"
            },

            new HairStyleEntity
            {
                HairStyleId = 4,
                HairStyleName = "Long Flowing Locks"
            },

            new HairStyleEntity
            {
                HairStyleId = 5,
                HairStyleName = "Braided Warrior's Tresses"
            },

            new HairStyleEntity
            {
                HairStyleId = 6,
                HairStyleName = "Windswept Curls"
            },

            new HairStyleEntity
            {
                HairStyleId = 7,
                HairStyleName = "Elven Pointed Braid"
            },

            new HairStyleEntity
            {
                HairStyleId = 8,
                HairStyleName = "Shaved Sides with Top Knot"
            },

            new HairStyleEntity
            {
                HairStyleId = 9,
                HairStyleName = "Sorceress's Long Braid"
            },

            new HairStyleEntity
            {
                HairStyleId = 10,
                HairStyleName = "Half-Shaved, Half-Long"
            },

            new HairStyleEntity
            {
                HairStyleId = 11,
                HairStyleName = "Pirate's Dreadlocks with Beads"
            },

            new HairStyleEntity
            {
                HairStyleId = 12,
                HairStyleName = "Spiky Anime Style"
            },

            new HairStyleEntity
            {
                HairStyleId = 13,
                HairStyleName = "Bald and Tattooed"
            },

            new HairStyleEntity
            {
                HairStyleId = 14,
                HairStyleName = "Braided Beard with Rings"
            },

            new HairStyleEntity
            {
                HairStyleId = 15,
                HairStyleName = "Mohawk with Tribal Tattoos"
            }
        );

        modelBuilder.Entity<WeaponEntity>().HasData(
            new WeaponEntity
            {
                WeaponId = 1,
                WeaponName = "Celestial Bow of Radiance",
                WeaponType = "Bow and Arrow",
                WeaponDescription = " A radiant bow blessed by celestial beings, firing arrows of divine light that can smite darkness and heal allies.",
                WeaponIsARangedWeapon = true,
                WeaponIsAMeleeWeapon = false,
                WeaponGeneratesSplashDamage = true,
                RangedWeaponDistance = "20 meters",
                WeaponDamageAmount = 35,
                WeaponSplashDamageAmount = 10
            },

            new WeaponEntity
            {
                WeaponId = 2,
                WeaponName = "Rogue's Dagger of Shadows",
                WeaponType = "Dagger",
                WeaponDescription = " A concealed dagger used by rogues for stealthy assassinations, designed to leave no trace behind.",
                WeaponIsARangedWeapon = false,
                WeaponIsAMeleeWeapon = true,
                WeaponGeneratesSplashDamage = false,
                RangedWeaponDistance = "",
                WeaponDamageAmount = 35,
                WeaponSplashDamageAmount = 0
            },

            new WeaponEntity
            {
                WeaponId = 3,
                WeaponName = "Dragonfire Staff",
                WeaponType = "Mage Staff",
                WeaponDescription = " A staff that channels the power of dragons, allowing the caster to unleash devastating fire spells.",
                WeaponIsARangedWeapon = true,
                WeaponIsAMeleeWeapon = false,
                WeaponGeneratesSplashDamage = true,
                RangedWeaponDistance = "20 meters",
                WeaponDamageAmount = 40,
                WeaponSplashDamageAmount = 15
            },

            new WeaponEntity
            {
                WeaponId = 4,
                WeaponName = " Vorpal Blade",
                WeaponType = " Katana",
                WeaponDescription = " A razor-sharp sword that can sever heads with a single swing, a weapon favored by those seeking decapitating strikes.",
                WeaponIsARangedWeapon = false,
                WeaponIsAMeleeWeapon = true,
                WeaponGeneratesSplashDamage = false,
                RangedWeaponDistance = "",
                WeaponDamageAmount = 65,
                WeaponSplashDamageAmount = 0
            },

            new WeaponEntity
            {
                WeaponId = 5,
                WeaponName = " Dwarven Warhammer",
                WeaponType = " WarHammer",
                WeaponDescription = "A massive and sturdy warhammer forged in dwarven forges, able to crush opponents and breach defenses.",
                WeaponIsARangedWeapon = false,
                WeaponIsAMeleeWeapon = true,
                WeaponGeneratesSplashDamage = true,
                RangedWeaponDistance = "",
                WeaponDamageAmount = 45,
                WeaponSplashDamageAmount = 15
            },

            new WeaponEntity
            {
                WeaponId = 6,
                WeaponName = " Necromancer's Scythe",
                WeaponType = " Scythe",
                WeaponDescription = " A menacing scythe associated with necromancers, capable of harvesting souls and controlling the undead.",
                WeaponIsARangedWeapon = false,
                WeaponIsAMeleeWeapon = true,
                WeaponGeneratesSplashDamage = false,
                RangedWeaponDistance = "",
                WeaponDamageAmount = 50,
                WeaponSplashDamageAmount = 0
            },

            new WeaponEntity
            {
                WeaponId = 7,
                WeaponName = "Jester's Trickster Cane",
                WeaponType = "Sword",
                WeaponDescription = "A cane with concealed tricks and traps, used by jesters and pranksters for both entertainment and subterfuge.",
                WeaponIsARangedWeapon = true,
                WeaponIsAMeleeWeapon = true,
                WeaponGeneratesSplashDamage = true,
                RangedWeaponDistance = "5 meters",
                WeaponDamageAmount = 30,
                WeaponSplashDamageAmount = 15
            },

            new WeaponEntity
            {
                WeaponId = 8,
                WeaponName = "Elven Longbow",
                WeaponType = "Bow And Arrow",
                WeaponDescription = "A cane with concealed tricks and traps, used by jesters and pranksters for both entertainment and subterfuge.",
                WeaponIsARangedWeapon = true,
                WeaponIsAMeleeWeapon = false,
                WeaponGeneratesSplashDamage = true,
                RangedWeaponDistance = "35 meters",
                WeaponDamageAmount = 45,
                WeaponSplashDamageAmount = 15
            },

            new WeaponEntity
            {
                WeaponId = 9,
                WeaponName = " Excalibur",
                WeaponType = " Sword",
                WeaponDescription = " The legendary sword of King Arthur, said to be the most powerful and righteous weapon in the realm, capable of vanquishing evil.",
                WeaponIsARangedWeapon = false,
                WeaponIsAMeleeWeapon = true,
                WeaponGeneratesSplashDamage = true,
                RangedWeaponDistance = "35 meters",
                WeaponDamageAmount = 65,
                WeaponSplashDamageAmount = 20
            }
        );

        modelBuilder.Entity<GameEntity>().HasData(
            new GameEntity
            {
                GameId = 1,
                GameName = "Into the Heart of Darkness",
                GameDescription = "|  In a realm where magic and might coexist, the land teeters on the precipice of darkness.\n" +
                                    "|  Unlikely heros must rise up, each from vastly different backgrounds, to embark on a journey\n" +
                                    "|  that will determine the fate of their world. These four heroes are on separate paths, yet the \n" +
                                    "|  echoes of their destinies are inextricably linked. As they come together, they will unlock the secrets \n" +
                                    "|  of ancient artifacts, face unspeakable evils, and unite against a malevolent force that threatens to plunge \n" +
                                    "|  the world into darkness. Welcome to a world of magic, valor, cunning, and the unknown. The fate of the realm rests \n" +
                                    "|  in your hands. Will you rise to the occasion and uncover the truth behind the Rise of the Ancients",

                DateCreated = DateTimeOffset.Now
            }

        );
    }
}

