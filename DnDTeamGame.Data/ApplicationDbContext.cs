using DnDTeamGame.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DnDTeamGame.Data;

public class ApplicationDbContext : IdentityDbContext<UserEntity, IdentityRole<int>, int>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }
    
    public DbSet<CharacterClassEntity> CharacterClasses {get; set;} = null!;
    public DbSet<WeaponEntity> Weapons {get; set;} = null!;
    public DbSet<ConsumableEntity> Consumables {get; set;} = null!;
    public DbSet<VehicleEntity> Vehicles {get; set;} = null!;
    public DbSet<ArmourEntity> Armours {get; set;} = null!;
    public DbSet<HairStyleEntity> HairStyles {get; set;} = null!;
    public DbSet<HairColorEntity> HairColors {get; set;} = null!;
    public DbSet<AbilityEntity> Abilities {get; set;} = null!;
    public DbSet<BodyTypeEntity> BodyTypes {get; set;} = null!;
    public DbSet<CharacterEntity> Characters {get; set;} = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UserEntity>().ToTable("Users");
    }
}