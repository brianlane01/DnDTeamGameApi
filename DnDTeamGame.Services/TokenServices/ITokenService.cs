using DnDTeamGame.Models.TokenModels;

namespace DnDTeamGame.Services.TokenServices
{
    public interface ITokenService
    {
        Task<TokenResponse?> GetTokenAsync(TokenRequest model);
    }
}