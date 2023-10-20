using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DnDTeamGame.Data.Entities
{
    
    public class CharacterClassEntity
    {
        [Key]
        public int CharacterClassId { get; set; }

        [Required]
        public string CharacterClassName { get; set; } = string.Empty;

    }
}