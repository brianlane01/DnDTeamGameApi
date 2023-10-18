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
    }
}