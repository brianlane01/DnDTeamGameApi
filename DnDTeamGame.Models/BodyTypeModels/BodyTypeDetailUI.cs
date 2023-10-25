using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace DnDTeamGame.Models.BodyTypeModels
{
    public class BodyTypeDetailUI
    {
        [JsonProperty("bodyTypeId")]
        [JsonPropertyName("bodyTypeId")]
        public int BodyTypeId { get; set; }

        [JsonProperty("bodyTypeName")]
        [JsonPropertyName("bodyTypeName")]
        public string BodyTypeName { get; set; } = string.Empty;
    }
}