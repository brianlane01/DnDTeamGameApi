using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DnDTeamGame.Models.MapModels
{
    public class MapDetailsUI
    {
        [JsonProperty("mapId")]
        [JsonPropertyName("mapId")]
        public int MapId { get; set; }

        [JsonProperty("mapName")]
        [JsonPropertyName("mapName")]
        public string MapName { get; set; }

        [JsonProperty("mapType")]
        [JsonPropertyName("mapType")]
        public string MapType { get; set; }

        [JsonProperty("mapDescription")]
        [JsonPropertyName("mapDescription")]
        public string MapDescription { get; set; }

        [JsonProperty("isDayTime")]
        [JsonPropertyName("isDayTime")]
        public bool IsDaytime { get; set; }

        [JsonProperty("precipitationType")]
        [JsonPropertyName("precipitationType")]
        public string PrecipitationType { get; set; }
    }
}