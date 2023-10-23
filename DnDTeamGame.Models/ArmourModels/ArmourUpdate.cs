using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DnDTeamGame.Models.ArmourModels
{
    public class ArmourUpdate
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
    }
}