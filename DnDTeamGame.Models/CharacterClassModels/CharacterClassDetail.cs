using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DnDTeamGame.Models.CharacterClassModels
{
    public class CharacterClassDetail
    {
        public int CharacterClassId { get; set; }

        public string CharacterClassName { get; set; } = string.Empty;

        public string CharacterClassDescription { get; set; }

        public string CharacterClassSpecialAbility { get; set; } = string.Empty;

        //* Determines What Kind of Special Ability the Class Has
  
        public bool SpecialAbilityIsAnAttack { get; set; }
        
        public bool SpecialAbilityHeals { get; set; }
        
        public bool SpecialAbilityProvidesDefense { get; set; }
        
        public bool SpecialAbilityProvidesStatusEffect { get; set; }

        //todo Determines the Amount of what the SpecialAbility does.
        
        public int SpecialAbilityDamage { get; set; }

        public int SpecialAbilityHealingAmount { get; set; }

        public int SpeacialAbilityDefenseAmount { get; set; }
        [Required]
        public string SpecialAbilityDuration { get; set; } = string.Empty;

        //* Provides a description of the SpecialAbility

        public string SpecialAbilityDescription { get; set; }

        public string ClassBackstoryForCharacter { get; set; } = string.Empty;
    }
}