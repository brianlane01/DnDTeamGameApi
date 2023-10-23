using System;
using DnDTeamGame.Data;
using DnDTeamGame.Data.Entities;
using DnDTeamGame.Models.BodyTypeModels;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DnDTeamGame.Services.BodyTypeServices
{
    public class BodyTypeService : IBodyTypeService
    {

        private readonly ApplicationDbContext _dbContext;

        public BodyTypeService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BodyTypeList?> CreateBodyTypeAsync(BodyTypeCreate request)
        {
            BodyTypeEntity entity = new()
            {
                BodyTypeName = request.BodyTypeName,

            };
            _dbContext.BodyTypes.Add(entity);
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            if (numberOfChanges != 1)
                return null;
            BodyTypeList response = new()
            {
                BodyTypeId = entity.BodyTypeId,
                BodyTypeName = entity.BodyTypeName,

            };
            return response;
        }

        public async Task<bool> DeleteBodyTypeAsync(int bodyTypeId)
        {
            var bodyTypeEntity = await _dbContext.BodyTypes.FindAsync(bodyTypeId);
            if (bodyTypeEntity == null)
                return false;
            _dbContext.BodyTypes.Remove(bodyTypeEntity);
            return await _dbContext.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<BodyTypeList>> GetAllBodyTypesAsync()
        {
            List<BodyTypeList> BodyTypes = await _dbContext.BodyTypes

            .Select(entity => new BodyTypeList
            {
                BodyTypeId = entity.BodyTypeId,
                BodyTypeName = entity.BodyTypeName,
            })
            .ToListAsync();
            return BodyTypes;
        }

        public async Task<BodyTypeDetail?> GetBodyTypeByIdAsync(int bodyTypeId)
        {
            BodyTypeEntity? entity = await _dbContext.BodyTypes
            .FirstOrDefaultAsync(e => e.BodyTypeId == bodyTypeId);
            return entity is null ? null : new BodyTypeDetail
            {
                BodyTypeId = entity.BodyTypeId,
                BodyTypeName = entity.BodyTypeName
            };

        }


        public async Task<bool> UpdateBodyTypeAsync(BodyTypeUpdate request)
        {
            BodyTypeEntity? entity = await _dbContext.BodyTypes.FindAsync(request.BodyTypeId);
            if (entity == null)
                return false;
            entity.BodyTypeId = request.BodyTypeId;
            entity.BodyTypeName = request.BodyTypeName;

            int numberOfChanges = await _dbContext.SaveChangesAsync();

            return numberOfChanges == 1;
        }


    }
}
