using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DnDTeamGame.Models.HairStyleModels
{
    public class HairStyleDetail
    {
        public int HairStyleId { get; set; }

        [Required]
        public string HairStyleName { get; set; }
    }
}