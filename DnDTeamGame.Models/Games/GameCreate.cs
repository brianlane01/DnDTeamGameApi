using System.ComponentModel.DataAnnotations;

namespace DnDTeamGame.Models.Games
{
    public class GameCreate
    {

        [Required, MaxLength(250)]
        public string? GameName {get; set;}

        [Required, MaxLength(500)]
        public string? GameDescription {get; set;}

        [Required]
        public DateTimeOffset DateCreated {get; set;}
    }
}