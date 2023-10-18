using DnDTeamGame.Models.UserModels;

namespace DnDTeamGame.Services.UserServices;

public interface IUserService 
{
    Task<bool> RegisterUserAsync(UserRegister model);
    Task<UserDetail?> GetUserByIdAsync(int userId);
    Task<bool> DeleteUserAsync(int userId);
}