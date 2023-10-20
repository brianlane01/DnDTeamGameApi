using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DnDTeamGame.Models.MapModels;
public class MapCreate
{
    [Required]
    public int GameId { get; set; }
    [Required]
    [MinLength(1, ErrorMessage = "{0} Must be at least{1} Characters long."), MaxLength(100, ErrorMessage = "{0} Must be no more than{1} Characters long.")]
    public string MapType { get; set; }
    [Required]
    [MinLength(1, ErrorMessage = "{0} Must be at least{1} Characters long."), MaxLength(100, ErrorMessage = "{0} Must be no more than{1} Characters long.")]
    public string MapName { get; set; }
    [Required]
    [MinLength(1, ErrorMessage = "{0} Must be at least{1} Characters long."), MaxLength(500, ErrorMessage = "{0} Must be no more than{1} Characters long.")]
    public string MapDescription { get; set; }
    [Required]
    public bool IsDayTime { get; set; }
    [Required]
    [MinLength(1, ErrorMessage = "{0} Must be at least{1} Characters long."), MaxLength(100, ErrorMessage = "{0} Must be no more than{1} Characters long.")]
    public string PrecipitationType { get; set; }
}
