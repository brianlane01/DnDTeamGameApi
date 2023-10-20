using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnDTeamGame.Data;
using DnDTeamGame.Data.Entities;
using DnDTeamGame.Models.VehicleModels;
using Microsoft.EntityFrameworkCore;

namespace DnDTeamGame.Services.VehicleServices
{
    public class VehicleService : IVehicleService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly int _userId;
        private readonly int _characterId;
        public VehicleService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<VehicleListItem?> CreateVehicleAsync(VehicleCreate request)
        {
            VehicleEntity entity = new VehicleEntity()
            {
                // CharacterId = request.CharacterId,
                VehicleName = request.VehicleName,
                VehicleSpeed = request.VehicleSpeed,
                VehicleAbility = request.VehicleAbility,
                VehicleType = request.VehicleType,
                VehicleDescription = request.VehicleDescription,
                VehicleAttackDamage = request.VehicleAttackDamage,
                VehicleHealth = request.VehicleHealth

            };


            _dbContext.Vehicles.Add(entity);
            var numberOfChanges = await _dbContext.SaveChangesAsync();

            if (numberOfChanges !=1)
                return null;

            VehicleListItem response = new()
            {
                VehicleId = entity.VehicleId,
                // CharacterId = entity.CharacterId,
                VehicleName = entity.VehicleName,
                VehicleSpeed = entity.VehicleSpeed,
                VehicleAbility = entity.VehicleAbility,
                VehicleType = entity.VehicleType,
                VehicleDescription = entity.VehicleDescription,
                VehicleAttackDamage = entity.VehicleAttackDamage,
                VehicleHealth = entity.VehicleHealth
            };

            return response;
        }

        public async Task<bool> DeleteVehicleAsync(int vehicleId)
        {
            var vehicleEntity = await _dbContext.Vehicles.FindAsync(vehicleId);

            if (vehicleEntity == null)
                return false;

            _dbContext.Vehicles.Remove(vehicleEntity);
            return await _dbContext.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<VehicleListItem>> GetAllVehiclesAsync()
        {
            List<VehicleListItem> vehicles = await _dbContext.Vehicles
            .Select(entity => new VehicleListItem
            {
                VehicleId = entity.VehicleId,
                // CharacterId = entity.CharacterId,
                VehicleName = entity.VehicleName,
                VehicleSpeed = entity.VehicleSpeed,
                VehicleAbility = entity.VehicleAbility,
                VehicleType = entity.VehicleType,
                VehicleDescription = entity.VehicleDescription,
                VehicleAttackDamage = entity.VehicleAttackDamage,
                VehicleHealth = entity.VehicleHealth
            })
            .ToListAsync();

            return vehicles;
        }

        public async Task<VehicleDetail?> GetVehicleByCharacterIdAsync(int CharacterId)
        {
            VehicleEntity? entity = await _dbContext.Vehicles
            .FirstOrDefaultAsync(e => e.VehicleId == CharacterId);

            return entity is null ? null : new VehicleDetail
            {
                VehicleId = entity.VehicleId,
                VehicleName = entity.VehicleName,
                VehicleSpeed = entity.VehicleSpeed,
                VehicleAbility = entity.VehicleAbility,
                VehicleType = entity.VehicleType,
                VehicleDescription = entity.VehicleDescription,
                VehicleAttackDamage = entity.VehicleAttackDamage,
                VehicleHealth = entity.VehicleHealth
            };
        }

        public async Task<bool> UpdateVehicleAsync(VehicleUpdate request)
        {
            VehicleEntity? entity = await _dbContext.Vehicles.FindAsync(request.VehicleId);

            if(entity == null)
                return false;
            
            entity.VehicleName = request.VehicleName;
            entity.VehicleSpeed = request.VehicleSpeed;
            entity.VehicleAbility = request.VehicleAbility;
            entity.VehicleType = request.VehicleType;
            entity.VehicleDescription = request.VehicleDescription;
            entity.VehicleAttackDamage = request.VehicleAttackDamage;
            entity.VehicleHealth = request.VehicleHealth;

            int numberOfChanges = await _dbContext.SaveChangesAsync();

            return numberOfChanges == 1;
      
        }
    }
}