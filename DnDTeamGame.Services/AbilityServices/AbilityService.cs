using System;
using DnDTeamGame.Data;
using DnDTeamGame.Data.Entities;
using DnDTeamGame.Models.AbilityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

namespace DnDTeamGame.Services.AbilityServices
{
    public class AbilityService : IAbilityService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public AbilityService(ApplicationDbContext dbContext,
                                IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<AbilityDetail?> CreateNewAbilityAsync(AbilityCreate request)
        {
            var abilityEntity = _mapper.Map<AbilityCreate, AbilityEntity>(request);
            _dbContext.Abilities.Add(abilityEntity);
            var numberOfChanges = await _dbContext.SaveChangesAsync();

            if (numberOfChanges == 1)
            {
                AbilityDetail response = _mapper.Map<AbilityEntity, AbilityDetail>(abilityEntity);
                return response;
            }

            return null;
            // AbilityEntity entity = new AbilityEntity()
            // {
            //     AbilityName = request.AbilityName,
            //     AbilityDescription = request.AbilityDescription,
            //     AbilityEffectType = request.AbilityEffectType,
            //     AbilityEffectAttack = request.AbilityEffectAttack,
            //     AbilityEffectHealthEnhancement = request.AbilityEffectHealthEnhancement,
            //     AbilityEffectDefenseEnhancement = request.AbilityEffectDefenseEnhancement,
            //     AbilityHasStatusEffect = request.AbilityHasStatusEffect,
            //     AbilityDamageSingleEnemy = request.AbilityDamageSingleEnemy,
            //     AbilityDamageMultipleEnemy = request.AbilityDamageMultipleEnemy,
            //     AbilityAttackDamage = request.AbilityAttackDamage,
            //     AbilityHealingAmount = request.AbilityHealingAmount,
            //     AbilityDefenseIncrease = request.AbilityDefenseIncrease,
            //     AbilityEffectTimeLimit = request.AbilityEffectTimeLimit
            // };

            // var newAbilityCreated = _dbContext.Abilities.Add(entity);
            // var abilityAdded = await _dbContext.SaveChangesAsync();

            // AbilityDetail response = new AbilityDetail()
            // {
            //     AbilityId = entity.AbilityId,
            //     AbilityName = entity.AbilityName,
            //     AbilityDescription = entity.AbilityDescription,
            //     AbilityEffectType = entity.AbilityEffectType,
            //     AbilityEffectAttack = entity.AbilityEffectAttack,
            //     AbilityEffectHealthEnhancement = entity.AbilityEffectHealthEnhancement,
            //     AbilityEffectDefenseEnhancement = entity.AbilityEffectDefenseEnhancement,
            //     AbilityHasStatusEffect = entity.AbilityHasStatusEffect,
            //     AbilityDamageSingleEnemy = entity.AbilityDamageSingleEnemy,
            //     AbilityDamageMultipleEnemy = entity.AbilityDamageMultipleEnemy,
            //     AbilityAttackDamage = entity.AbilityAttackDamage,
            //     AbilityHealingAmount = entity.AbilityHealingAmount,
            //     AbilityDefenseIncrease = entity.AbilityDefenseIncrease,
            //     AbilityEffectTimeLimit = entity.AbilityEffectTimeLimit           
            // };

            // return response; 
        }


        public async Task<IEnumerable<AbilityListItem>> GetAllAbilitiesAsync()
        {
            var abilities = await _dbContext.Abilities
                .Select(entity => _mapper.Map<AbilityEntity, AbilityListItem>(entity))
                .ToListAsync();

            return abilities;
            // List<AbilityListItem> abilities = await _dbContext.Abilities
            // .Select(entity => new AbilityList
            // {
            //     AbilityId = entity.AbilityId,
            //     AbilityName = entity.AbilityName,
            //     AbilityDescription = entity.AbilityDescription
            // })
            // .ToListAsync();

            // return abilities;

        }

        public async Task<AbilityDetail?> GetAbilityByIdAsync(int abilityId)
        {
            var abilityEntity = await _dbContext.Abilities
                .FirstOrDefaultAsync(e => e.AbilityId == abilityId);
            
            return abilityEntity is null ? null : _mapper.Map<AbilityEntity, AbilityDetail>(abilityEntity);

            // AbilityEntity? entity = await _dbContext.Abilities
            // .FirstOrDefaultAsync(e => e.AbilityId == abilityId);
            // return entity is null ? null : new AbilityDetail
            // {
            //     AbilityId = entity.AbilityId,
            //     AbilityName = entity.AbilityName,
            //     AbilityDescription = entity.AbilityDescription,
            //     AbilityEffectType = entity.AbilityEffectType,
            //     AbilityEffectAttack = entity.AbilityEffectAttack,
            //     AbilityEffectHealthEnhancement = entity.AbilityEffectHealthEnhancement,
            //     AbilityEffectDefenseEnhancement = entity.AbilityEffectDefenseEnhancement,
            //     AbilityHasStatusEffect = entity.AbilityHasStatusEffect,
            //     AbilityDamageSingleEnemy = entity.AbilityDamageSingleEnemy,
            //     AbilityDamageMultipleEnemy = entity.AbilityDamageMultipleEnemy,
            //     AbilityAttackDamage = entity.AbilityAttackDamage,
            //     AbilityHealingAmount = entity.AbilityHealingAmount,
            //     AbilityDefenseIncrease = entity.AbilityDefenseIncrease,
            //     AbilityEffectTimeLimit = entity.AbilityEffectTimeLimit
            // };
        }

        public async Task<bool> UpdateAbilityAsync(AbilityUpdate request)
        {
            var abilityExists = await _dbContext.Abilities.AnyAsync(ability => 
            ability.AbilityId == request.AbilityId);

            if(!abilityExists)
                return false;
            
            var newEntity = _mapper.Map<AbilityUpdate, AbilityEntity>(request);

            _dbContext.Entry(newEntity).State = EntityState.Modified;

            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteAbilityAsync(int abilityId)
        {
        var abilityEntity = await _dbContext.Abilities.FindAsync(abilityId);
        if (abilityEntity == null)
            return false;
        _dbContext.Abilities.Remove(abilityEntity);
        return await _dbContext.SaveChangesAsync() == 1;
        }
    }
}