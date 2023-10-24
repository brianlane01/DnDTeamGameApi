using System.ComponentModel.DataAnnotations;
using DnDTeamGame.Data.Entities;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace DnDTeamGame.Models.UserModels
{
    public class UserDetailUI
    {
        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonProperty("userName")]
        [JsonPropertyName("userName")]
        public string UserName { get; set; } = null!;

        [JsonProperty("firstName")]
        [JsonPropertyName("firstName")]
        public string? FirstName { get; set; }  

        [JsonProperty("lastName")]
        [JsonPropertyName("lastName")]
        public string? LastName { get; set; }

        [JsonProperty("email")]
        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;
    }
}