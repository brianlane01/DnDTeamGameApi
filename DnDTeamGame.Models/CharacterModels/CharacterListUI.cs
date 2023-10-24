using System.ComponentModel.DataAnnotations;
using DnDTeamGame.Data.Entities;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace DnDTeamGame.Models.CharacterModels
{
    public class CharacterListUI
    {
        [JsonProperty("characterId")]
        [JsonPropertyName("characterId")]
        public int CharacterId { get; set; }

        [JsonProperty("characterName")]
        [JsonPropertyName("characterName")]
        public string CharacterName { get; set; }

        [JsonProperty("characterDescription")]
        [JsonPropertyName("characterDescription")]
        public string CharacterDescription { get; set; }

        [JsonProperty("characterHealth")]
        [JsonPropertyName("characterHealth")]
        public int CharacterHealth { get; set; }

        [JsonProperty("characterBaseAttackDamage")]
        [JsonPropertyName("characterBaseAttackDamage")]
        public int CharacterBaseAttackDamage { get; set; }

        [JsonProperty("characterBaseDefense")]
        [JsonPropertyName("characterBaseDefense")]
        public int CharacterBaseDefense { get; set; }

        [JsonProperty("dateCreated")]
        [JsonPropertyName("dateCreated")]
        public DateTime DateCreated { get; set; }

        [JsonProperty("dateModified")]
        [JsonPropertyName("dateModified")]
        public object DateModified { get; set; }

        [JsonProperty("hairColorName")]
        [JsonPropertyName("hairColorName")]
        public string HairColorName { get; set; }

        [JsonProperty("hairStyleName")]
        [JsonPropertyName("hairStyleName")]
        public string HairStyleName { get; set; }

        [JsonProperty("characterClassName")]
        [JsonPropertyName("characterClassName")]
        public string CharacterClassName { get; set; }

        [JsonProperty("characterClassDescription")]
        [JsonPropertyName("characterClassDescription")]
        public string CharacterClassDescription { get; set; }

        [JsonProperty("abilityName")]
        [JsonPropertyName("abilityName")]
        public List<string> AbilityName { get; set; }

        [JsonProperty("abilityDescription")]
        [JsonPropertyName("abilityDescription")]
        public List<string> AbilityDescription { get; set; }

        [JsonProperty("vehicleName")]
        [JsonPropertyName("vehicleName")]
        public List<string> VehicleName { get; set; }

        [JsonProperty("vehicleDescription")]
        [JsonPropertyName("vehicleDescription")]
        public List<string> VehicleDescription { get; set; }

        [JsonProperty("weaponName")]
        [JsonPropertyName("weaponName")]
        public List<string> WeaponName { get; set; }

        [JsonProperty("weaponDescription")]
        [JsonPropertyName("weaponDescription")]
        public List<string> WeaponDescription { get; set; }

        [JsonProperty("armourName")]
        [JsonPropertyName("armourName")]
        public List<string> ArmourName { get; set; }

        [JsonProperty("armourDescription")]
        [JsonPropertyName("armourDescription")]
        public List<string> ArmourDescription { get; set; }

        [JsonProperty("consumableName")]
        [JsonPropertyName("consumableName")]
        public List<string> ConsumableName { get; set; }

        [JsonProperty("consumableDescription")]
        [JsonPropertyName("consumableDescription")]
        public List<string> ConsumableDescription { get; set; }
    }
}