using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace DnDTeamGame.Models.WeaponModels
{
    public class WeaponDetailUI
    {
        [JsonProperty("weaponId")]
        [JsonPropertyName("weaponId")]
        public int WeaponId { get; set; }

        [JsonProperty("weaponName")]
        [JsonPropertyName("weaponName")]
        public string WeaponName { get; set; } = null!;

        [JsonProperty("weaponType")]
        [JsonPropertyName("weaponType")]
        public string? WeaponType { get; set; } 

        
        [JsonProperty("weaponDescription")]
        [JsonPropertyName("weaponDescription")] 
        public string WeaponDescription {get; set;}

        [JsonProperty("weaponIsARangedWeapon")]
        [JsonPropertyName("weaponIsARangedWeapon")] 
        public bool WeaponIsARangedWeapon { get; set; }


        [JsonProperty("weaponIsAMeleeWeapon")]
        [JsonPropertyName("weaponIsAMeleeWeapon")]
        public bool WeaponIsAMeleeWeapon { get; set; }


        [JsonProperty("weaponGeneratesSplashDamage")]
        [JsonPropertyName("weaponGeneratesSplashDamage")] 
        public bool WeaponGeneratesSplashDamage { get; set; }

        [JsonProperty("rangedWeaponDistance")]
        [JsonPropertyName("rangedWeaponDistance")]
        public string RangedWeaponDistance { get; set; }

        [JsonProperty("weaponSplashDamageAmount")]
        [JsonPropertyName("weaponSplashDamageAmount")]
        public int WeaponSplashDamageAmount { get; set; }

        [JsonProperty("weaponDamageAmount")]
        [JsonPropertyName("weaponDamageAmount")] 
        public int WeaponDamageAmount { get; set; }

    }
}