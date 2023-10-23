using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnDTeamGame.Models.HairColorModels;

namespace DnDTeamGame.Services.HairColorServices
{
    public interface IHairColorService
    {
         Task<HairColorDetail?> CreateNewHairColorAsync(HairColorCreate request);
        Task<IEnumerable<HairColorList>> GetAllHairColorsAsync();
        Task<HairColorDetail?> GetHairColorByIdAsync(int hairStyleId);
        Task<bool> UpdateHairColorAsync(HairColorUpdate request);
        Task<bool> DeleteHairColorAsync(int hairStyleId);
    }
}