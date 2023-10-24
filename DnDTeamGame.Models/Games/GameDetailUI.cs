using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace DnDTeamGame.Models.Games
{
    public class GameDetailUI
    {
        [JsonProperty("gameId")]
        [JsonPropertyName("gameId")]
        public int GameId { get; set; }

        [JsonProperty("gameName")]
        [JsonPropertyName("gameName")]
        public string GameName { get; set; } = null!;

        [JsonProperty("gameDescription")]
        [JsonPropertyName("gameDescription")]
        public string? GameDescription { get; set; } 

        
        [JsonProperty("userId")]
        [JsonPropertyName("userId")] 
        public int UserId {get; set;}

    }
}