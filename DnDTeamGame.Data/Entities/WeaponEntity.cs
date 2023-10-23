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

        [Required]
        public string WeaponType { get; set; }

        [Required]
        public string WeaponDescription { get; set; }

        [Required]
        public bool WeaponIsARangedWeapon { get; set; }
        [Required]
        public bool WeaponIsAMeleeWeapon { get; set; }
        [Required]
        public bool WeaponGeneratesSplashDamage { get; set; }

        [Required]
        public string RangedWeaponDistance { get; set; }
        [Required]
        public int WeaponDamageAmount { get; set; }
        [Required]
        public int WeaponSplashDamageAmount { get; set; }

        public ICollection<CharacterEntity> CharacterList { get; set; }
        public WeaponEntity()
        {
            CharacterList = new HashSet<CharacterEntity>();
        }
    }
}