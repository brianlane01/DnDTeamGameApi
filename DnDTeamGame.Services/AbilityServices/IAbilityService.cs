
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnDTeamGame.Models.AbilityModels;

namespace DnDTeamGame.Services.AbilityServices
{
    public interface IAbilityService
    {
        Task<AbilityDetail?> CreateNewAbilityAsync(AbilityCreate request);
        Task<IEnumerable<AbilityListItem?>> GetAllAbilitiesAsync();
        Task<AbilityDetail?> GetAbilityByIdAsync(int abilityId);
        Task<bool> UpdateAbilityAsync(AbilityUpdate request);
        Task<bool> DeleteAbilityAsync(int abilityId);
    }
}