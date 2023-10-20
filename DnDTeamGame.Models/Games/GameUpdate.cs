using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DnDTeamGame.Models.Games
{
    public class GameUpdate
    {
        [Required]
        public int GameId {get; set;}

        [Required, MaxLength(250)]
        public string? GameName {get; set;}

        [Required,MaxLength(500)]
        public string? GameDescription {get; set;}

        [Required]
        public int UserId {get; set;}


        [Required]
        public DateTimeOffset DateCreated {get; set;}
    }
}