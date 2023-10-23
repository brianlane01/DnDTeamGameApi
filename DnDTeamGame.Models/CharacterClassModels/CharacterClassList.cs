using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DnDTeamGame.Models.CharacterClassModels
{
    public class CharacterClassList
    {
        public int CharacterClassId { get; set; }
        public string CharacterClassName { get; set; } = string.Empty;
        public string CharacterClassDescription { get; set; }
    }
}