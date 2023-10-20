using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DnDTeamGame.Data.Entities
{
    public class BodyTypeEntity
    {
        [Key]
        public int BodyTypeId { get; set; }

        [Required]
        public string BodyTypeName { get; set; } = string.Empty;

    }
}