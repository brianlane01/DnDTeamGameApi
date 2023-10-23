using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DnDTeamGame.Models.AbilityModels
{
    public class AbilityListItem
    {
        public int AbilityId { get; set; }

        [Required, MinLength(4), MaxLength(50)]
        public string AbilityName { get; set; } = string.Empty;

        [Required, MinLength(8), MaxLength(7500)]
        public string AbilityDescription { get; set; } = string.Empty;
    }
}