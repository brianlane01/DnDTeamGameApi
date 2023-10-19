using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnDTeamGame.Models.VehicleModels
{
    public class VehicleListItem
    {

        public int VehicleId { get; set; }
        public int CharacterId { get; set; }
        
        public string VehicleName { get; set; } = string.Empty;

        public double VehicleSpeed { get; set; }

        public string VehicleAbility { get; set; } = string.Empty;

        public string VehicleType { get; set; } = string.Empty;

        public string VehicleDescription { get; set; } = string.Empty;

        public int VehicleAttackDamage { get; set; }

        public double VehicleHealth { get; set; }
    }
}