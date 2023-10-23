using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnDTeamGame.Models.WeaponModels
{
    public class WeaponDetail
    {
        public int WeaponId {get; set;}

        public string WeaponName { get; set; } = string.Empty;

        public string WeaponType { get; set; }

        public string WeaponDescription { get; set; }

        public bool WeaponIsARangedWeapon { get; set; }

        public bool WeaponIsAMeleeWeapon { get; set; }

        public bool WeaponGeneratesSplashDamage { get; set; }

        public string RangedWeaponDistance { get; set; }

        public int WeaponSplashDamageAmount { get; set; }
        
        public int WeaponDamageAmount { get; set; }
        
    }
}