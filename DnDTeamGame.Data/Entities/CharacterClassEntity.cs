using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DnDTeamGame.Data.Entities
{
    
    public class CharacterClassEntity
    {
        [Key]
        public int CharacterClassId { get; set; }

        [Required]
        public string CharacterClassName { get; set; } = string.Empty;

        [Required, MinLength(4), MaxLength(750)]
        public string CharacterClassDescription { get; set; }

        [Required]
        public string CharacterClassSpecialAbility { get; set; } = string.Empty;

        //* Determines What Kind of Special Ability the Class Has
        [Required]
        public bool SpecialAbilityIsAnAttack { get; set; }
        [Required]
        public bool SpecialAbilityHeals { get; set; }
        [Required]
        public bool SpecialAbilityProvidesDefense { get; set; }
        [Required]
        public bool SpecialAbilityProvidesStatusEffect { get; set; }

        //todo Determines the Amount of what the SpecialAbility does.
        [Required, Range(0, 100)]
        public int SpecialAbilityDamage { get; set; }

        [Required, Range(0, 100)]
        public int SpecialAbilityHealingAmount { get; set; }

        [Required, Range(0, 100)]
        public int SpeacialAbilityDefenseAmount { get; set; }
        [Required]
        public string SpecialAbilityDuration { get; set; } = string.Empty;

        //* Provides a description of the SpecialAbility
        [Required, MinLength(4), MaxLength(750)]
        public string SpecialAbilityDescription { get; set; }
    }
}