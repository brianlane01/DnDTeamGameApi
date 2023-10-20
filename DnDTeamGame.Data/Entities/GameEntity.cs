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

        [Required,MaxLength(500)]
        public string? GameDescription {get; set;}

        [Required]
        public DateTimeOffset DateCreated { get; set; }

        public DateTimeOffset? DateModified {get; set;}

        [ForeignKey(nameof(Games))]
        public int UserId {get; set;}
        public UserEntity Games {get; set;} = null!;

    }
}