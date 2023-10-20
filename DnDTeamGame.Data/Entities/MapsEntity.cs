using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;


namespace DnDTeamGame.Data.Entities;
public class MapEntity
{
    [Key]
    public int MapId { get; set; }
    [Required, MinLength(1), MaxLength(100)]
    public string MapName { get; set; }
    [Required, MinLength(1), MaxLength(100)]
    public string MapType { get; set; }
    [Required, MinLength(1), MaxLength(500)]
    public string MapDescription { get; set; }
    [Required]
    public bool IsDayTime { get; set; }
    [Required, MinLength(1), MaxLength(100)]
    public string PrecipitationType { get; set; }
    public int GameId { get; set; }
    // public GameEntity Game { get; set; }
}


