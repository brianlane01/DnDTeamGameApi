using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DnDTeamGame.Data.Entities
{
    public class CharacterEntity
    {
        [Key]
        public int CharacterId { get; set; }

        [Required, MinLength(4), MaxLength(25)]
        public string CharacterName { get; set; } = string.Empty;

        [Required, Range(1, 350)]
        public int CharacterHealth { get; set; } 

        [Required, Range(1, 10)]
        public double CharacterBaseAttackDamage { get; set; }

        [Required, Range(1, 10)]
        public int CharacterBaseDefense { get; set; } 

        [Required]
        public string CharacterDescription { get; set; }

        [Required]
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateModified { get; set; }

        // public int GameId { get; set; }
        // public GameEntity Game { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public UserEntity User { get; set; }

        [ForeignKey(nameof(CharacterClass))]
        public int CharacterClassId { get; set; }
        public virtual CharacterClassEntity CharacterClass { get; set; }

        [ForeignKey(nameof(BodyType))]
        public int BodyTypeId { get; set; }
        public virtual BodyTypeEntity BodyType { get; set; }

        [ForeignKey(nameof(HairStyle))]
        public int HairStyleId { get; set; }
        public virtual HairStyleEntity HairStyle { get; set; }

        [ForeignKey(nameof(HairColor))]
        public int HairColorId { get; set; }
        public virtual HairColorEntity HairColor { get; set; }

        public virtual ICollection<AbilityEntity> AbilitiesList { get; set; }        
        public virtual ICollection<WeaponEntity> WeaponsList { get; set; }
        public virtual ICollection<ArmourEntity> ArmoursList { get; set; }
        public virtual ICollection<ConsumableEntity> ConsumablesList { get; set; }
        public virtual ICollection<VehicleEntity> VehiclesList  {get; set;} 

        public CharacterEntity ()
        {
            AbilitiesList = new HashSet<AbilityEntity>();
            WeaponsList = new HashSet<WeaponEntity>();
            ArmoursList = new HashSet<ArmourEntity>();
            ConsumablesList = new List<ConsumableEntity>();
            VehiclesList = new HashSet<VehicleEntity>();
        }
    }
}