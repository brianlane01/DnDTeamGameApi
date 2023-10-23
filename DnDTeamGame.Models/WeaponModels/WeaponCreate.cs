using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DnDTeamGame.Models.WeaponModels
{
    public class WeaponCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "{0} must be at least {1} characters long.")]
        [MaxLength(100, ErrorMessage = "{0} must be no more than {1} characters long")]
        public string WeaponName { get; set; } = string.Empty;

        [Required]
        [MinLength(1, ErrorMessage = "{0} must be at least {1} characters long.")]
        [MaxLength(100, ErrorMessage = "{0} must be no more than {1} characters long")]
        public string WeaponType { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "{0} must be at least {1} characters long.")]
        [MaxLength(100, ErrorMessage = "{0} must be no more than {1} characters long")]
        public string WeaponDescription { get; set; }

        [Required]
        public bool WeaponIsARangedWeapon { get; set; }

        [Required]
        public bool WeaponIsAMeleeWeapon { get; set; }

        [Required]
        public bool WeaponGeneratesSplashDamage { get; set; }

        [Required]
        public string? RangedWeaponDistance { get; set; }


        [Required]
        public int WeaponSplashDamageAmount { get; set; }

        [Required]
        public int WeaponDamageAmount { get; set; }

    }
}