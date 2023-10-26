using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DnDTeamGame.Data.Entities
{
    public class GameEntity
    {
        [Key]
        public int GameId { get; set; }

        [MaxLength(250)]
        public string? GameName {get; set;}

        [Required,MaxLength(7500)]
        public string? GameDescription {get; set;}

        [Required]
        public DateTimeOffset DateCreated { get; set; }

        public DateTimeOffset? DateModified {get; set;}

    }
}