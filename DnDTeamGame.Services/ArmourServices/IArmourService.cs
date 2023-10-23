using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnDTeamGame.Models.ArmourModels;

namespace DnDTeamGame.Services.ArmourServices
{
    public interface IArmourService
    {
        Task<ArmourDetail?> CreateNewArmourAsync(ArmourCreate request);
        Task<IEnumerable<ArmourList>> GetAllArmoursAsync();
        Task<ArmourDetail?> GetArmourByIdAsync(int armourId);
        Task<bool> UpdateArmourAsync(ArmourUpdate request);
        Task<bool> DeleteArmourAsync(int armourId);
    }
}