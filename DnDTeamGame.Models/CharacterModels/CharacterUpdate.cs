using System.ComponentModel.DataAnnotations;

namespace DnDTeamGame.Models.CharacterModels
{
    public class CharacterUpdate
    {
        [Required, MinLength(4, ErrorMessage = "{0} must be at least {1} characters long."), MaxLength(25)]
        public string CharacterName { get; set; } = string.Empty;

        [Required, Range(1, 350)]
        public int CharacterHealth { get; set; } 

        [Required, Range(1, 10)]
        public double CharacterBaseAttackDamage { get; set; }

        [Required, Range(1, 10)]
        public int CharacterBaseDefense { get; set; } 

        [Required]
        public string CharacterDescription { get; set; } = string.Empty;

        public List<int> AbiltyId { get; set; }
        public List<int> WeaponId { get; set; }
        public List<int> HairColorId { get; set; }
        public List<int> HairStyleId { get; set; }
        public List<int> BodyTypeId { get; set; }
        public List<int> ArmourId { get; set; }
        public List<int> ConsumableId { get; set; }
        public List<int> VehicleId { get; set; }
    }
}