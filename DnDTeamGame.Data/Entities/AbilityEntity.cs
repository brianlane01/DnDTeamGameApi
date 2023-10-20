using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace DnDTeamGame.Data.Entities
{
    
    public class AbilityEntity
    {
        [Key]
        public int AbilityId { get; set; }
        public string AbilityName { get; set; } = string.Empty;

        public ICollection<CharacterEntity> CharacterList { get; set; }

        public AbilityEntity()
        {
            CharacterList = new HashSet<CharacterEntity>();
        }
    }
}