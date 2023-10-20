using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DnDTeamGame.Data.Entities
{
    public class WeaponEntity
    {
        [Key]
        public int WeaponId { get; set; }

        [Required]
        public string WeaponName { get; set; } = string.Empty;
        public ICollection<CharacterEntity> CharacterList { get; set; }
        public WeaponEntity()
        {
            CharacterList = new HashSet<CharacterEntity>();
        }
    }
}