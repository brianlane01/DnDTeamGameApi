using System;
using DnDTeamGame.Data;
using DnDTeamGame.Data.Entities;
using DnDTeamGame.Models.ConsumableModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

namespace DnDTeamGame.Services.ConsumableServices
{
    public class ConsumableService : IConsumableService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ConsumableService(ApplicationDbContext dbContext,
                                IMapper mapper)
        {   
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ConsumableDetail?> CreateNewConsumableAsync(ConsumableCreate request)
        {
            var consumableEntity = _mapper.Map<ConsumableCreate, ConsumableEntity>(request);
            _dbContext.Consumables.Add(consumableEntity);
            var numberOfChanges = await _dbContext.SaveChangesAsync();

            if (numberOfChanges == 1)
            {
                ConsumableDetail response = _mapper.Map<ConsumableEntity, ConsumableDetail>(consumableEntity);
                return response;
            }

            return null;
        }

        public async Task<IEnumerable<ConsumableDetail>> GetAllConsumablesAsync()
        {
            var consumables = await _dbContext.Consumables
                .Select(entity => _mapper.Map<ConsumableEntity, ConsumableDetail>(entity))
                .ToListAsync();

            return consumables;
        }

        public async Task<ConsumableDetail?> GetConsumableByIdAsync(int consumableId)
        {
            var consumableEntity = await _dbContext.Consumables
                .FirstOrDefaultAsync(e => e.ConsumableId == consumableId);
            
            return consumableEntity is null ? null : _mapper.Map<ConsumableEntity, ConsumableDetail>(consumableEntity);

        }

        public async Task<bool> UpdateConsumableAsync(ConsumableUpdate request)
        {
            var consumableExists = await _dbContext.Consumables.AnyAsync(consumable => 
            consumable.ConsumableId == request.ConsumableId);

            if(!consumableExists)
                return false;
            
            var newEntity = _mapper.Map<ConsumableUpdate, ConsumableEntity>(request);

            _dbContext.Entry(newEntity).State = EntityState.Modified;

            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteConsumableAsync(int consumableId)
        {
        var consumableEntity = await _dbContext.Consumables.FindAsync(consumableId);
        if (consumableEntity == null)
            return false;
        _dbContext.Consumables.Remove(consumableEntity);
        return await _dbContext.SaveChangesAsync() == 1;
        }
    }
}