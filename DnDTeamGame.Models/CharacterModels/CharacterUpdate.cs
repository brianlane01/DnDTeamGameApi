using System.ComponentModel.DataAnnotations;

namespace DnDTeamGame.Models.CharacterModels
{
    public class CharacterUpdate
    {
        [Required]
        public int CharacterId { get; set; }
        
        [Required, MinLength(4, ErrorMessage = "{0} must be at least {1} characters long."), MaxLength(25)]
        public string CharacterName { get; set; } = string.Empty;

        public DateTimeOffset? DateModified { get; set; }


        [Required]
        public string CharacterDescription { get; set; } = string.Empty;

        public int HairColorId { get; set; }
        public int HairStyleId { get; set; }
        public int BodyTypeId { get; set; }
        // public int CharacterClassId { get; set; }
        public int UserId { get; set; }

        public List<int> AbilityList { get; set; }
        public List<int> WeaponList { get; set; }
        public List<int> ArmourList { get; set; }
        public List<int> ConsumableList { get; set; }
        public List<int> VehicleList { get; set; }
        
    }
}