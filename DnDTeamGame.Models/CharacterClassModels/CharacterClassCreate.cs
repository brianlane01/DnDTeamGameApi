using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DnDTeamGame.Models.CharacterClassModels
{
    public class CharacterClassCreate
    {
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

        public string ClassBackstoryForCharacter { get; set; } = string.Empty;
    }
}