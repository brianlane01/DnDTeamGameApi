using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DnDTeamGame.Data.Entities
{
    
    public class HairColorEntity
    {
        [Key]
        public int HairColorId { get; set; }

        [Required]
        public string HairColorName { get; set; }

        public ICollection<CharacterEntity> CharacterList { get; set; }
        public HairColorEntity()
        {
            CharacterList = new HashSet<CharacterEntity>();
        }
    }
}