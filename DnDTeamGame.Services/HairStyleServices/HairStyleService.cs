using System;
using DnDTeamGame.Data;
using DnDTeamGame.Data.Entities;
using DnDTeamGame.Models.HairStyleModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

namespace DnDTeamGame.Services.HairStyleServices
{
    public class HairStyleService : IHairStyleService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public HairStyleService(ApplicationDbContext dbContext,
                                IMapper mapper)
        {   
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<HairStyleDetail?> CreateNewHairStyleAsync(HairStyleCreate request)
        {
            var hairStyleEntity = _mapper.Map<HairStyleCreate, HairStyleEntity>(request);
            _dbContext.HairStyles.Add(hairStyleEntity);
            var numberOfChanges = await _dbContext.SaveChangesAsync();

            if (numberOfChanges == 1)
            {
                HairStyleDetail response = _mapper.Map<HairStyleEntity, HairStyleDetail>(hairStyleEntity);
                return response;
            }

            return null;
        }

        public async Task<IEnumerable<HairStyleList>> GetAllHairStylesAsync()
        {
            var hairStyles = await _dbContext.HairStyles
                .Select(entity => _mapper.Map<HairStyleEntity, HairStyleList>(entity))
                .ToListAsync();

            return hairStyles;
        }

        public async Task<HairStyleDetail?> GetHairStyleByIdAsync(int hairStyleId)
        {
            var hairStyleEntity = await _dbContext.HairStyles
                .FirstOrDefaultAsync(e => e.HairStyleId == hairStyleId);
            
            return hairStyleEntity is null ? null : _mapper.Map<HairStyleEntity, HairStyleDetail>(hairStyleEntity);

        }

        public async Task<bool> UpdateHairStyleAsync(HairStyleUpdate request)
        {
            var hairStyleExists = await _dbContext.HairStyles.AnyAsync(hairStyle => 
            hairStyle.HairStyleId == request.HairStyleId);

            if(!hairStyleExists)
                return false;
            
            var newEntity = _mapper.Map<HairStyleUpdate, HairStyleEntity>(request);

            _dbContext.Entry(newEntity).State = EntityState.Modified;

            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteHairStyleAsync(int hairStyleId)
        {
        var hairStyleEntity = await _dbContext.HairStyles.FindAsync(hairStyleId);
        if (hairStyleEntity == null)
            return false;
        _dbContext.HairStyles.Remove(hairStyleEntity);
        return await _dbContext.SaveChangesAsync() == 1;
        }
    }
    
}