using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DnDTeamGame.Data.Entities
{
    public class ArmourEntity
    {
        [Key]
        public int ArmourId { get; set; }

        [Required]
        public string ArmourName { get; set; } = string.Empty;

        public ICollection<CharacterEntity> CharacterList { get; set; }
        public ArmourEntity()
        {
            CharacterList = new HashSet<CharacterEntity>();
        }
    }
}