using System;
using DnDTeamGame.Data;
using DnDTeamGame.Data.Entities;
using DnDTeamGame.Models.CharacterClassModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

namespace DnDTeamGame.Services.CharacterClassServices
{
    public class CharacterClassService : ICharacterClassService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public CharacterClassService(ApplicationDbContext dbContext,
                                        IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CharacterClassDetail?> CreateNewCharacterClassAsync(CharacterClassCreate request)
        {
            var characterClassEntity = _mapper.Map<CharacterClassCreate, CharacterClassEntity>(request);
            _dbContext.CharacterClasses.Add(characterClassEntity);
            var numberOfChanges = await _dbContext.SaveChangesAsync();

            if (numberOfChanges == 1)
            {
                CharacterClassDetail response = _mapper.Map<CharacterClassEntity, CharacterClassDetail>(characterClassEntity);
                return response;
            }

            return null;
        }

        public async Task<IEnumerable<CharacterClassDetail>> GetAllCharacterClassesAsync()
        {
            var characterClasses = await _dbContext.CharacterClasses
                .Select(entity => _mapper.Map<CharacterClassEntity, CharacterClassDetail>(entity))
                .ToListAsync();

            return characterClasses;
        }

        public async Task<CharacterClassDetail?> GetCharacterClassByIdAsync(int characterClassId)
        {
            var characterClassEntity = await _dbContext.CharacterClasses
                .FirstOrDefaultAsync(e => e.CharacterClassId == characterClassId);
            
            return characterClassEntity is null ? null : _mapper.Map<CharacterClassEntity, CharacterClassDetail>(characterClassEntity);

        }

        public async Task<bool> UpdateCharacterClassAsync(CharacterClassUpdate request)
        {
            var characterClassExists = await _dbContext.CharacterClasses.AnyAsync(characterClass => 
            characterClass.CharacterClassId == request.CharacterClassId);

            if(!characterClassExists)
                return false;
            
            var newEntity = _mapper.Map<CharacterClassUpdate, CharacterClassEntity>(request);

            _dbContext.Entry(newEntity).State = EntityState.Modified;

            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteCharacterClassAsync(int characterClassId)
        {
        var characterClassEntity = await _dbContext.CharacterClasses.FindAsync(characterClassId);
        if (characterClassEntity == null)
            return false;
        _dbContext.CharacterClasses.Remove(characterClassEntity);
        return await _dbContext.SaveChangesAsync() == 1;
        }
    }
}