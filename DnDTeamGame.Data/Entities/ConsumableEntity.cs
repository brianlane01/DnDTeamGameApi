using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DnDTeamGame.Data.Entities
{
    
    public class ConsumableEntity
    {
        [Key]
        public int ConsumableId { get; set; }

        [Required, MaxLength(50)]
        public string ConsumableName { get; set; }

        // [Required, Range(0, 10)]
        // public double Quantity { get; set; }

        [Required, MinLength(1), MaxLength(250)]
        public string ConsumableDescription { get; set; }

        [Required, MinLength(1), MaxLength(250)]
        public string ConsumableEffect { get; set; }

        [Required]
        public bool ConsumableIncreaseHealth { get; set; }

        [Required]
        public bool ConsumableIncreaseDefense { get; set; }

        [Required]
        public bool ConsumableIncreaseAttack { get; set; }

        [Required]
        public bool ConsumableDoesDamageToEnemy { get; set; }

        public int? ConsumableHealthIncreaseAmount { get; set; }
        public int? ConsumableDefenseIncreaseAmount { get; set; }
        public int? ConsumableAttackIncreaseAmount { get; set; }
        public string? ConsumableDamageToEnemy { get; set; } = string.Empty;

        public ICollection<CharacterEntity> CharacterList { get; set; }
        public ConsumableEntity()
        {
            CharacterList = new HashSet<CharacterEntity>();
        }

    }
}