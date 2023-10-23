using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DnDTeamGame.Models.ConsumableModels
{
    public class ConsumableCreate
    {
        [Required, MaxLength(50)]
        public string ConsumableName { get; set; }


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

    }
}