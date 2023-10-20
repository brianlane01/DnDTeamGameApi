using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnDTeamGame.Models.MapModels
{
    public class MapListItem
    {
        public int MapId { get; set; }
        public int GameId { get; set; }
        public string MapName { get; set; }
        public string MapDescription { get; set; }
    }
}