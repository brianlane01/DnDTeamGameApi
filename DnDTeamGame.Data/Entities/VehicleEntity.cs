using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DnDTeamGame.Data.Entities
{
    public class VehicleEntity
    {
        [Key]
        public int VehicleId {get; set;}

        [Required, MinLength(1), MaxLength(100)]
        public string VehicleName { get; set; } = string.Empty;

        [Required]
        public double VehicleSpeed { get; set; }

        [Required, MinLength(1), MaxLength(100)]
        public string VehicleAbility { get; set; } = string.Empty;

        [Required, MinLength(1), MaxLength(100)]
        public string VehicleType { get; set; } = string.Empty;

        [Required, MinLength(1), MaxLength(500)]
        public string VehicleDescription { get; set; } = string.Empty;

        [Required]
        public int VehicleAttackDamage { get; set; }

        [Required]
        public double VehicleHealth { get; set; }

        [Required]
        [ForeignKey(nameof(CharacterId))]
        public int CharacterId { get; set; }
        public CharacterEntity Character { get; set; } = null!
    }
}