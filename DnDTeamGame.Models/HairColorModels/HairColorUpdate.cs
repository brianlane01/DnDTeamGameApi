using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DnDTeamGame.Models.HairColorModels
{
    public class HairColorUpdate
    {
        public int HairColorId { get; set; }

        [Required]
        public string HairColorName { get; set; }
    }
}