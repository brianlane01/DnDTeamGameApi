

namespace DnDTeamGame.Models.UserModels
{
    public class UserDetail
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string? FirstName { get; set; }  
        public string? LastName { get; set; }
        public string Email { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
    }
}