using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnDTeamGame.Models.HairStyleModels;

namespace DnDTeamGame.Services.HairStyleServices
{
    public interface IHairStyleService
    {
        Task<HairStyleDetail?> CreateNewHairStyleAsync(HairStyleCreate request);
        Task<IEnumerable<HairStyleList>> GetAllHairStylesAsync();
        Task<HairStyleDetail?> GetHairStyleByIdAsync(int hairStyleId);
        Task<bool> UpdateHairStyleAsync(HairStyleUpdate request);
        Task<bool> DeleteHairStyleAsync(int hairStyleId);
    }
}