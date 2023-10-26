using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace DnDTeamGame.Models.HairColorModels
{
    public class HairColorDetailUI
    {
        [JsonProperty("hairColorId")]
        [JsonPropertyName("hairColorId")]
        public int HairColorId { get; set; }

        [JsonProperty("hairColorName")]
        [JsonPropertyName("hairColorName")]
        public string HairColorName { get; set; }
    }
}