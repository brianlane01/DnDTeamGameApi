using System;
using DnDTeamGame.Data;
using DnDTeamGame.Data.Entities;
using DnDTeamGame.Models.HairColorModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

namespace DnDTeamGame.Services.HairColorServices
{
    public class HairColorService : IHairColorService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public HairColorService(ApplicationDbContext dbContext,
                                IMapper mapper)
        {   
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<HairColorDetail?> CreateNewHairColorAsync(HairColorCreate request)
        {
            var hairColorEntity = _mapper.Map<HairColorCreate, HairColorEntity>(request);
            _dbContext.HairColors.Add(hairColorEntity);
            var numberOfChanges = await _dbContext.SaveChangesAsync();

            if (numberOfChanges == 1)
            {
                HairColorDetail response = _mapper.Map<HairColorEntity, HairColorDetail>(hairColorEntity);
                return response;
            }

            return null;
        }

        public async Task<IEnumerable<HairColorList>> GetAllHairColorsAsync()
        {
            var hairColors = await _dbContext.HairColors
                .Select(entity => _mapper.Map<HairColorEntity, HairColorList>(entity))
                .ToListAsync();

            return hairColors;
        }

        public async Task<HairColorDetail?> GetHairColorByIdAsync(int hairColorId)
        {
            var hairColorEntity = await _dbContext.HairColors
                .FirstOrDefaultAsync(e => e.HairColorId == hairColorId);
            
            return hairColorEntity is null ? null : _mapper.Map<HairColorEntity, HairColorDetail>(hairColorEntity);

        }

        public async Task<bool> UpdateHairColorAsync(HairColorUpdate request)
        {
            var hairColorExists = await _dbContext.HairColors.AnyAsync(hairColor => 
            hairColor.HairColorId == request.HairColorId);

            if(!hairColorExists)
                return false;
            
            var newEntity = _mapper.Map<HairColorUpdate, HairColorEntity>(request);

            _dbContext.Entry(newEntity).State = EntityState.Modified;

            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteHairColorAsync(int hairColorId)
        {
        var hairColorEntity = await _dbContext.HairColors.FindAsync(hairColorId);
        if (hairColorEntity == null)
            return false;
        _dbContext.HairColors.Remove(hairColorEntity);
        return await _dbContext.SaveChangesAsync() == 1;
        }
    }
}