using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace DnDTeamGame.Models.HairStyleModels
{
    public class HairStyleDetailUI
    {
        [JsonProperty("hairStyleId")]
        [JsonPropertyName("hairStyleId")]
        public int HairStyleId { get; set; }

        [JsonProperty("hairStyleName")]
        [JsonPropertyName("hairStyleName")]
        public string HairStyleName { get; set; }
    }
}