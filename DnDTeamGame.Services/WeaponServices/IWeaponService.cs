using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnDTeamGame.Models.WeaponModels;

namespace DnDTeamGame.Services.WeaponServices
{
    public interface IWeaponService
    {
        Task<WeaponList?> CreateWeaponAsync(WeaponCreate request);
        
        Task<IEnumerable<WeaponList>> GetAllWeaponsAsync();

        Task<WeaponDetail?> GetWeaponByIdAsync(int weaponId);

        Task<bool> UpdateWeaponsAsync(WeaponUpdate request);

        Task<bool> DeleteWeaponsAsync(int weaponId);


    }
}