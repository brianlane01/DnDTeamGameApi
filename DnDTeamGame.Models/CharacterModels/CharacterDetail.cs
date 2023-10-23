namespace DnDTeamGame.Models.CharacterModels
{
    public class CharacterDetail
    {
        public int CharacterId { get; set; }
        public string CharacterName { get; set; } = string.Empty;
        public string CharacterDescription { get; set; } = string.Empty;
        public int CharacterHealth { get; set; }
        public double CharacterBaseAttackDamage { get; set; }
        public int CharacterBaseDefense { get; set; }

        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateModified { get; set; }

        public string? HairColorName { get; set; }
        public string? HairStyleName { get; set; }
        public string? CharacterClassName { get; set; }
        public string? CharacterClassDescription { get; set; }

        public  List<string> AbilityName { get; set; }
        public  List<string> AbilityDescription { get; set; }
        public List<string> VehicleName  { get; set; }
        public List<string> VehicleDescription  { get; set; }
        public List<string> WeaponName { get; set; }
        public List<string> WeaponDescription { get; set; }
        public List<string> ArmourName { get; set; }
        public List<string> ArmourDescription { get; set; }
        public List<string> ConsumableName { get; set; }
        public List<string> ConsumableDescription { get; set; }

    }
}