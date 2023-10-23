using System;
using DnDTeamGame.Data;
using DnDTeamGame.Data.Entities;
using DnDTeamGame.Models.ArmourModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

namespace DnDTeamGame.Services.ArmourServices
{
    public class ArmourService : IArmourService
    {
        private readonly ApplicationDbContext _dbContext; 
        private readonly IMapper _mapper;

        public ArmourService(ApplicationDbContext dbContext,
                                IMapper mapper)
        {   
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ArmourDetail?> CreateNewArmourAsync(ArmourCreate request)
        {
            var armourEntity = _mapper.Map<ArmourCreate, ArmourEntity>(request);
            _dbContext.Armours.Add(armourEntity);
            var numberOfChanges = await _dbContext.SaveChangesAsync();

            if (numberOfChanges == 1)
            {
                ArmourDetail response = _mapper.Map<ArmourEntity, ArmourDetail>(armourEntity);
                return response;
            }

            return null;
        }

        public async Task<IEnumerable<ArmourList>> GetAllArmoursAsync()
        {
            var armours = await _dbContext.Armours
                .Select(entity => _mapper.Map<ArmourEntity, ArmourList>(entity))
                .ToListAsync();

            return armours;
        }

        public async Task<ArmourDetail?> GetArmourByIdAsync(int armourId)
        {
            var armourEntity = await _dbContext.Armours
                .FirstOrDefaultAsync(e => e.ArmourId == armourId);
            
            return armourEntity is null ? null : _mapper.Map<ArmourEntity, ArmourDetail>(armourEntity);

        }

        public async Task<bool> UpdateArmourAsync(ArmourUpdate request)
        {
            var armourExists = await _dbContext.Armours.AnyAsync(armour => 
            armour.ArmourId == request.ArmourId);

            if(!armourExists)
                return false;
            
            var newEntity = _mapper.Map<ArmourUpdate, ArmourEntity>(request);

            _dbContext.Entry(newEntity).State = EntityState.Modified;

            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteArmourAsync(int armourId)
        {
        var armourEntity = await _dbContext.Armours.FindAsync(armourId);
        if (armourEntity == null)
            return false;
        _dbContext.Armours.Remove(armourEntity);
        return await _dbContext.SaveChangesAsync() == 1;
        }
    }
}