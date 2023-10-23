using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DnDTeamGame.Models.ArmourModels
{
    public class ArmourList
    {
        [Key]
        public int ArmourId { get; set; }

        [Required]
        public string ArmourName { get; set; } = string.Empty;
        [Required, MinLength(4), MaxLength(500)]
        public string ArmourDescription { get; set; } =string.Empty;

    }
}