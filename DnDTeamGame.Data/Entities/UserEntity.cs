using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DnDTeamGame.Data.Entities
{
    public class UserEntity : IdentityUser<int>
    {
        [MaxLength(50)]
        public string? FirstName {get; set;}

        [MaxLength(50)]
        public string? LastName { get; set; }
        
        [Required]
        public DateTime DateCreated { get; set; }

        public List<GameEntity> Games {get; set;} = new List<GameEntity>();

        public List<CharacterEntity> Characters { get; set; } = new List<CharacterEntity>();
    }
}