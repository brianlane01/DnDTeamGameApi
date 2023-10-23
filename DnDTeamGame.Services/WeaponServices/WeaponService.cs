using System;
using DnDTeamGame.Data;
using DnDTeamGame.Data.Entities;
using DnDTeamGame.Models.WeaponModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;


namespace DnDTeamGame.Services.WeaponServices
{
    public class WeaponService : IWeaponService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public WeaponService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<WeaponList?> CreateWeaponAsync(WeaponCreate request)
        {
            WeaponEntity entity = new WeaponEntity()
            {
                WeaponName = request.WeaponName,
                WeaponType = request.WeaponType, 
                WeaponDescription = request.WeaponDescription,
                WeaponIsARangedWeapon = request.WeaponIsARangedWeapon,
                WeaponIsAMeleeWeapon = request.WeaponIsAMeleeWeapon,
                WeaponGeneratesSplashDamage = request.WeaponGeneratesSplashDamage,
                RangedWeaponDistance = request.RangedWeaponDistance,
                WeaponSplashDamageAmount = request.WeaponSplashDamageAmount,
                WeaponDamageAmount = request.WeaponDamageAmount
            };

            _dbContext.Weapons.Add(entity);
            var numberOfChanges = await _dbContext.SaveChangesAsync();

            if (numberOfChanges != 1)
                return null;

            WeaponList response = new()
            {
                WeaponId = entity.WeaponId,
                WeaponName = entity.WeaponName,
                WeaponType = entity.WeaponType, 
                WeaponDescription = entity.WeaponDescription,
                WeaponIsARangedWeapon = entity.WeaponIsARangedWeapon,
                WeaponIsAMeleeWeapon = entity.WeaponIsAMeleeWeapon,
                WeaponGeneratesSplashDamage = entity.WeaponGeneratesSplashDamage,
                RangedWeaponDistance = entity.RangedWeaponDistance,
                WeaponSplashDamageAmount = entity.WeaponSplashDamageAmount,
                WeaponDamageAmount = entity.WeaponDamageAmount
            };
            return response;
        }

        public async Task<IEnumerable<WeaponList>> GetAllWeaponsAsync()
        {
            var weapons = await _dbContext.Weapons
                .Select(entity => _mapper.Map<WeaponEntity, WeaponList>(entity))
                .ToListAsync();
            return weapons;
        }

        public async Task<WeaponDetail?> GetWeaponByIdAsync(int weaponId)
        {
            var weaponEntity = await _dbContext.Weapons
                .FirstOrDefaultAsync(e => e.WeaponId == weaponId);

            return weaponEntity is null ? null : _mapper.Map<WeaponEntity, WeaponDetail>(weaponEntity);
        }

        public async Task<bool> UpdateWeaponsAsync(WeaponUpdate request)
        {
            var weaponExits = await _dbContext.Weapons.AnyAsync(weapon => weapon.WeaponId == request.WeaponId);
            
            if (!weaponExits)
                return false;
            
            var newEntity = _mapper.Map<WeaponUpdate, WeaponEntity>(request);

            _dbContext.Entry(newEntity).State = EntityState.Modified;

            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteWeaponsAsync(int weaponId)
        {
            var weaponEntity = await _dbContext.Weapons.FindAsync(weaponId);       

            if (weaponEntity == null)
                return false;

            _dbContext.Weapons.Remove(weaponEntity);

            return await _dbContext.SaveChangesAsync() == 1; 
        }
    }
}