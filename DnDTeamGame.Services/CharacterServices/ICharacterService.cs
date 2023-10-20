using DnDTeamGame.Models.CharacterModels;

namespace DnDTeamGame.Services.CharacterServices
{
    public interface ICharacterService
    {
        Task<CharacterDetail?> CreateCharacterAsync(CharacterCreate request);
        Task<IEnumerable<CharacterListItem?>> GetAllCharactersAsync();
    }
}