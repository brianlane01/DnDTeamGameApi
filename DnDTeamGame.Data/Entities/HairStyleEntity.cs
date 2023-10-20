using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DnDTeamGame.Data.Entities
{
    
    public class HairStyleEntity
    {
        [Key]
        public int HairStyleId { get; set; }

        [Required]
        public string HairStyleName { get; set; }
        
    }
}