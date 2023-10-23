using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnDTeamGame.Models.CharacterClassModels;

namespace DnDTeamGame.Services.CharacterClassServices
{
    public interface ICharacterClassService
    {
        Task<CharacterClassDetail?> CreateNewCharacterClassAsync(CharacterClassCreate request);
        Task<IEnumerable<CharacterClassList>> GetAllCharacterClassesAsync();
        Task<CharacterClassDetail?> GetCharacterClassByIdAsync(int characterClassId);
        Task<bool> UpdateCharacterClassAsync(CharacterClassUpdate request);
        Task<bool> DeleteCharacterClassAsync(int characterClassId);
    }
}