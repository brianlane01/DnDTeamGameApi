using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace DnDTeamGame.Models.ConsumableModels
{
    public class ConsumableDetailUI
    {
        [JsonProperty("consumableId")]
        [JsonPropertyName("consumableId")]
        public int ConsumableId { get; set; }
        
        [JsonProperty("consumableName")]
        [JsonPropertyName("consumableName")]
        public string ConsumableName { get; set; }

        [JsonProperty("consumableDescription")]
        [JsonPropertyName("consumableDescription")]
        public string ConsumableDescription { get; set; }

        [JsonProperty("consumableEffect")]
        [JsonPropertyName("consumableEffect")]
        public string ConsumableEffect { get; set; }

        [JsonProperty("consumableIncreaseHealth")]
        [JsonPropertyName("consumableIncreaseHealth")]
        public bool ConsumableIncreaseHealth { get; set; }

        [JsonProperty("consumableIncreaseDefense")]
        [JsonPropertyName("consumableIncreaseDefense")]
        public bool ConsumableIncreaseDefense { get; set; }

        [JsonProperty("consumableIncreaseAttack")]
        [JsonPropertyName("consumableIncreaseAttack")]
        public bool ConsumableIncreaseAttack { get; set; }

        [JsonProperty("consumableDoesDamageToEnemy")]
        [JsonPropertyName("consumableDoesDamageToEnemy")]
        public bool ConsumableDoesDamageToEnemy { get; set; }

        [JsonProperty("consumableHealthIncreaseAmount")]
        [JsonPropertyName("consumableHealthIncreaseAmount")]
        public int? ConsumableHealthIncreaseAmount { get; set; }

        [JsonProperty("consumableDefenseIncreaseAmount")]
        [JsonPropertyName("consumableDefenseIncreaseAmount")]
        public int? ConsumableDefenseIncreaseAmount { get; set; }

        [JsonProperty("consumableAttackIncreaseAmount")]
        [JsonPropertyName("consumableAttackIncreaseAmount")]    
        public int? ConsumableAttackIncreaseAmount { get; set; }

        [JsonProperty("consumableDamageToEnemy")]
        [JsonPropertyName("consumableDamageToEnemy")] 
        public string? ConsumableDamageToEnemy { get; set; } = string.Empty;
    }
}