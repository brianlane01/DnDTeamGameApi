using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace DnDTeamGame.Models.ArmourModels
{
    public class ArmourDetailUI
    {

        [JsonProperty("ArmourId")]
        [JsonPropertyName("ArmourId")]
        public int ArmourId { get; set; }

        [JsonProperty("ArmourName")]
        [JsonPropertyName("ArmourName")]
        public string ArmourName { get; set; } = string.Empty;
        [JsonProperty("ArmourDescription")]
        [JsonPropertyName("ArmourDescription")]
        public string ArmourDescription { get; set; } = string.Empty;

        [JsonProperty("ArmourProvideDefense")]
        [JsonPropertyName("ArmourProvideDefense")]
        public bool ArmourProvidesDefense { get; set; }

        [JsonProperty("ArmourIncreaseHealth")]
        [JsonPropertyName("ArmourIncreaseHealth")]
        public bool ArmourIncreasesHealth { get; set; }

        [JsonProperty("ArmourIncreasesSwordAttacks")]
        [JsonPropertyName("ArmourIncreasesSwordAttacks")]
        public bool ArmourIncreasesSwordAttacks { get; set; }

        [JsonProperty("ArmourIncreasesRangedAttacks")]
        [JsonPropertyName("ArmourIncreasesRangedAttacks")]
        public bool ArmourIncreasesRangedAttacks { get; set; }


        [JsonProperty("IncreasedHealthAmount")]
        [JsonPropertyName("IncreasedHealthAmount")]
        public int IncreasedHealthAmount { get; set; }
        [JsonProperty("IncreasedSwordDamageAmount")]
        [JsonPropertyName("IncreasedSwordDamageAmount")]
        public int IncreasedSwordDamageAmount { get; set; }
        [JsonProperty("IncreasedRangedAttackDamageAmount")]
        [JsonPropertyName("IncreasedRangedAttackDamageAmount")]
        public int IncreasedRangeAttackDamageAmount { get; set; }
        [JsonProperty("IncreasedDefenseAmount")]
        [JsonPropertyName("IncreasedDefenseAmount")]
        public int IncreasedDefenseAmount { get; set; }


        
        [JsonProperty("armourId")]
        [JsonPropertyName("armourId")]
        public int ArmourId { get; set; }

        [JsonProperty("armourName")]
        [JsonPropertyName("armourName")]
        public string ArmourName { get; set; } = string.Empty;

        [JsonProperty("armourDescription")]
        [JsonPropertyName("armourDescription")]
        public string ArmourDescription { get; set; } = string.Empty;

        [JsonProperty("armourProvidesDefense")]
        [JsonPropertyName("armourProvidesDefense")]
        public bool ArmourProvidesDefense { get; set; }

        [JsonProperty("armourIncreasesHealth")]
        [JsonPropertyName("armourIncreasesHealth")]
        public bool ArmourIncreasesHealth { get; set; }

        [JsonProperty("armourIncreasesSwordAttacks")]
        [JsonPropertyName("armourIncreasesSwordAttacks")]
        public bool ArmourIncreasesSwordAttacks { get; set; }

        [JsonProperty("armourIncreasesRangedAttacks")]
        [JsonPropertyName("armourIncreasesRangedAttacks")]
        public bool ArmourIncreasesRangedAttacks { get; set; }

        [JsonProperty("increasedHealthAmount")]
        [JsonPropertyName("increasedHealthAmount")]
        public int IncreasedHealthAmount { get; set; }

        [JsonProperty("increasedSwordDamageAmount")]
        [JsonPropertyName("increasedSwordDamageAmount")]
        public int IncreasedSwordDamageAmount { get; set; }

        [JsonProperty("increasedRangeAttackDamageAmount")]
        [JsonPropertyName("increasedRangeAttackDamageAmount")]
        public int IncreasedRangeAttackDamageAmount { get; set; }

        [JsonProperty("increasedDefenseAmount")]
        [JsonPropertyName("increasedDefenseAmount")]
        public int IncreasedDefenseAmount { get; set; }

    }
}