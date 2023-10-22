using System.ComponentModel.DataAnnotations;
using DnDTeamGame.Data.Entities;

namespace DnDTeamGame.Models.CharacterModels
{
    public class CharacterListItem
    {
        public int CharacterId { get; set; }
        public string CharacterName { get; set; } = string.Empty;
        public string CharacterDescription { get; set; } = string.Empty;
        
        public DateTimeOffset DateCreated { get; set; }
        
    }
}