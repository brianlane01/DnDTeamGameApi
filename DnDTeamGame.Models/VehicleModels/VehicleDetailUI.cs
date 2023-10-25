using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DnDTeamGame.Models.VehicleModels
{
    public class VehicleDetailUI
    {
        [JsonProperty("vehicleId")]
        [JsonPropertyName("vehicleId")]
        public int VehicleId { get; set; }

        [JsonProperty("vehicleName")]
        [JsonPropertyName("vehicleName")]
        public string VehicleName { get; set; } = string.Empty;

        [JsonProperty("vehicleSpeed")]
        [JsonPropertyName("vehicleSpeed")]
        public double VehicleSpeed { get; set; }

        
        [JsonProperty("vehicleAbility")]
        [JsonPropertyName("vehicleAbility")] 
        public string VehicleAbility { get; set; } = string.Empty;

        [JsonProperty("vehicleType")]
        [JsonPropertyName("vehicleType")] 
        public string VehicleType { get; set; } = string.Empty;


        [JsonProperty("vehicleDescription")]
        [JsonPropertyName("vehicleDescription")]
        public string VehicleDescription { get; set; } = string.Empty;


        [JsonProperty("vehicleAttackDamage")]
        [JsonPropertyName("vehicleAttackDamage")] 
        public int VehicleAttackDamage { get; set; }

        [JsonProperty("vehicleHealth")]
        [JsonPropertyName("vehicleHealth")]
        public double VehicleHealth { get; set; }

    }
}