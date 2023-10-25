using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace DnDTeamGame.Models.CharacterClassModels
{
    public class CharacterClassListUI
    {
        [JsonProperty("characterClassId")]
        [JsonPropertyName("CharacterClassId")]
        public int CharacterClassId { get; set; }

        [JsonProperty("characterClassName")]
        [JsonPropertyName("CharacterClassName")]
        public string CharacterClassName { get; set; } = string.Empty;

        [JsonProperty("characterClassDescription")]
        [JsonPropertyName("CharacterClassDescription")]
        public string CharacterClassDescription { get; set; }

        [JsonProperty("characterClassSpecialAbility")]
        [JsonPropertyName("CharacterClassSpecialAbility")]
        public string CharacterClassSpecialAbility { get; set; } = string.Empty;

        [JsonProperty("specialAbilityDescription")]
        [JsonPropertyName("specialAbilityDescription")]
        public string SpecialAbilityDescription { get; set; }

        [JsonProperty("specialAbilityIsAnAttack")]
        [JsonPropertyName("specialAbilityIsAnAttack")]
        public bool SpecialAbilityIsAnAttack { get; set; }

        [JsonProperty("specialAbilityHeals")]
        [JsonPropertyName("specialAbilityHeals")]
        public bool SpecialAbilityHeals { get; set; }

        [JsonProperty("specialAbilityProvidesDefense")]
        [JsonPropertyName("specialAbilityProvidesDefense")]
        public bool SpecialAbilityProvidesDefense { get; set; }

        [JsonProperty("specialAbilityProvidesStatusEffect")]
        [JsonPropertyName("specialAbilityProvidesStatusEffect")]
        public bool SpecialAbilityProvidesStatusEffect { get; set; }

        [JsonProperty("specialAbilityDamage")]
        [JsonPropertyName("specialAbilityDamage")]
        public int SpecialAbilityDamage { get; set; }

        [JsonProperty("specialAbilityHealingAmount")]
        [JsonPropertyName("specialAbilityHealingAmount")]
        public int SpecialAbilityHealingAmount { get; set; }

        [JsonProperty("specialAbilityDefenseAmount")]
        [JsonPropertyName("specialAbilityDefenseAmount")]
        public int SpeacialAbilityDefenseAmount { get; set; }

        [JsonProperty("specialAbilityDuration")]
        [JsonPropertyName("specialAbilityDuration")]
        public string SpecialAbilityDuration { get; set; } = string.Empty;
    }
}