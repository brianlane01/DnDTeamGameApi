using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnDTeamGame.Models.MapModels
{
    public class MapDetail
    {
        public int MapId { get; set; }
        public string MapName { get; set; }
        public string MapType { get; set; }
        public string MapDescription { get; set; }

        public bool IsDaytime { get; set; }
        public string PrecipitationType { get; set; }
    }
}