using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace DnDTeamGame.Models.AbilityModels
{
    public class AbilityDetailUI
    {

        [JsonProperty("AbilityId")]
        [JsonPropertyName("AbilityId")]
        public int AbilityId { get; set; }

        [JsonProperty("AbilityName")]
        [JsonPropertyName("AbilityName")]
        public string AbilityName { get; set; } = string.Empty;

        [JsonProperty("AbilityDescription")]
        [JsonPropertyName("AbilityDescription")]
        public string AbilityDescription { get; set; } = string.Empty;

        //* State if the ability is going to be an Attack, Healing, Defensive, 
        [JsonProperty("AbilityEffectType")]
        [JsonPropertyName("AbilityEffectType")]
        public string AbilityEffectType { get; set; }

        //* Determines what the effect of the Ability is going to have
        [JsonProperty("AbilityEffectAttack")]
        [JsonPropertyName("AbilityEffectAttack")]
        public bool AbilityEffectAttack { get; set; }
        [JsonProperty("AbilityEffectHealthEnhancement")]
        [JsonPropertyName("AbilityEffectHealthEnhancement")]
        public bool AbilityEffectHealthEnhancement { get; set; }
        [JsonProperty("AbilityEffectDefenseEnhancement")]
        [JsonPropertyName("AbilityEffectDefenseEnhancement")]
        public bool AbilityEffectDefenseEnhancement { get; set; }
        [JsonProperty("AbilityHasStatusEffect")]
        [JsonPropertyName("AbilityHasStatusEffect")]
        public bool AbilityHasStatusEffect { get; set; }

        //*Determines if the ability is going to affect one or more enemies if it is an attack type Ability
        [JsonProperty("AbilityDamageSingleEnemy")]
        [JsonPropertyName("AbilityDamageSingleEnemy")]
        public bool AbilityDamageSingleEnemy { get; set; }
        [JsonProperty("AbilityDamageMultipleEnemy")]
        [JsonPropertyName("AbilityDamageMultipleEnemy")]
        public bool AbilityDamageMultipleEnemy { get; set; }

        //* These Determine how much of something the Ability does or How long it may last.
        [JsonProperty("AbilityAttackDamage")]
        [JsonPropertyName("AbilityAttackDamage")]
        public int AbilityAttackDamage { get; set; }

        [JsonProperty("AbilityHealingAmount")]
        [JsonPropertyName("AbilityHealingAmount")]
        public int AbilityHealingAmount { get; set; }

        [JsonProperty("AbilityDefenseIncrease")]
        [JsonPropertyName("AbilityDefenseIncrease")]
        public int AbilityDefenseIncrease { get; set; }

        [JsonProperty("AbilityEffectTimeLimit")]
        [JsonPropertyName("AbilityEffectTimeLimit")]
        public string? AbilityEffectTimeLimit { get; set; } = string.Empty;

    }
}