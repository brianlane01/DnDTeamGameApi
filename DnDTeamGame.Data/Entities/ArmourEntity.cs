using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DnDTeamGame.Data.Entities
{
    public class ArmourEntity
    {
        [Key]
        public int ArmourId { get; set; }

        [Required]
        public string ArmourName { get; set; } = string.Empty;
        [Required, MinLength(4), MaxLength(500)]
        public string ArmourDescription { get; set; } =string.Empty;

        [Required]
        public bool ArmourProvidesDefense { get; set; }

        [Required]
        public bool ArmourIncreasesHealth { get; set; }

        [Required]
        public bool ArmourIncreasesSwordAttacks {get; set;}

        [Required]
        public bool ArmourIncreasesRangedAttacks { get; set; }


        [Required, Range(0, 100)]
        public int IncreasedHealthAmount { get; set; }
        [Required, Range(0, 100)]
        public int IncreasedSwordDamageAmount { get; set; }
        [Required, Range(0, 100)]
        public int IncreasedRangeAttackDamageAmount { get; set; }
        [Required, Range(0, 100)]
        public int IncreasedDefenseAmount { get; set; }


        public ICollection<CharacterEntity> CharacterList { get; set; }
        public ArmourEntity()
        {
            CharacterList = new HashSet<CharacterEntity>();
        }
    }
}