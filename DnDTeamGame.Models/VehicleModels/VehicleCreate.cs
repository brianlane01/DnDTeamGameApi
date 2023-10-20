using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DnDTeamGame.Models.VehicleModels
{
    public class VehicleCreate
    {
        [Required]
        public int CharacterId { get; set; }
        
        [Required]
        [MinLength(1, ErrorMessage = "{0} must be at least {1} characters long.")]
        [MaxLength(100, ErrorMessage = "{0} must be no more than {1} characters long")]
        public string VehicleName { get; set; } = string.Empty;

        [Required]
        public double VehicleSpeed { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "{0} must be at least {1} characters long.")]
        [MaxLength(100, ErrorMessage = "{0} must be no more than {1} characters long")]
        public string VehicleAbility { get; set; } = string.Empty;

        [Required]
        [MinLength(1, ErrorMessage = "{0} must be at least {1} characters long.")]
        [MaxLength(100, ErrorMessage = "{0} must be no more than {1} characters long")]
        public string VehicleType { get; set; } = string.Empty;

        [Required]
        [MinLength(1, ErrorMessage = "{0} must be at least {1} characters long.")]
        [MaxLength(500, ErrorMessage = "{0} must be no more than {1} characters long")]
        public string VehicleDescription { get; set; } = string.Empty;

        [Required]
        public int VehicleAttackDamage { get; set; }

        [Required]
        public double VehicleHealth { get; set; }

    }
}