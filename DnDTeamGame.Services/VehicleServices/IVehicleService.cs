using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnDTeamGame.Models.VehicleModels;

namespace DnDTeamGame.Services.VehicleServices
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleListItem>> GetAllVehiclesAsync();
        Task<VehicleListItem?> CreateVehicleAsync(VehicleCreate request);
        Task<VehicleDetail?> GetVehicleByCharacterIdAsync(int CharacterId);
        Task<bool> UpdateVehicleAsync(VehicleUpdate request);
        Task<bool> DeleteVehicleAsync(int VehicleId);
    }
}