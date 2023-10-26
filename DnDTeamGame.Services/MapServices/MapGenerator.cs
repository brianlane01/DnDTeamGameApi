using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using DnDTeamGame.Data;
using DnDTeamGame.Data.Entities;
using DnDTeamGame.Models.MapModels;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DnDTeamGame.Services.MapServices
{
    public class MapGenerator : IMapGenerator
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly int _userId;
        private readonly int _gameId;
        public MapGenerator(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task CreateMapAsync(MapCreate request)
        {
            throw new NotImplementedException();
        }

        public async Task<MapListItem> CreatMapAsync(MapCreate request)
        {
            MapEntity entity = new()
            {
                MapType = request.MapType,
                MapName = request.MapName,
                MapDescription = request.MapDescription,
                IsDayTime = request.IsDayTime,
                PrecipitationType = request.PrecipitationType,
                GameId = request.GameId
            };
            _dbContext.Maps.Add(entity);
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            if (numberOfChanges != 1)
                return null;
            MapListItem response = new()
            {
                MapId = entity.MapId,
                GameId = entity.GameId,
                MapName = entity.MapName,
                MapDescription = entity.MapDescription,
            };
            return response;
        }

        public async Task<bool> DeleteMapAsync(int GameId)
        {
            var mapEntity = await _dbContext.Maps.FindAsync(GameId);
            if (mapEntity == null)
                return false;
                
            _dbContext.Maps.Remove(mapEntity);
            return await _dbContext.SaveChangesAsync() == 1;
        }

        // public async Task<IEnumerable<MapListItem>> GetAllMapsAsync(MapCreate request)
        // {
        //     List<MapListItem> maps = await _dbContext.Maps
        //     .Where(entity => entity.MapId == _userId)
        //     .Select(entity => new MapListItem
        //     {
        //         MapId = entity.MapId,
        //         GameId = entity.GameId,
        //         MapName = entity.MapName,
        //         MapDescription = entity.MapDescription,
        //     })
        //     .ToListAsync();
        //     return maps;
        // }

        public async Task<MapDetail?> GetMapByGameIdAsync(int GameId)
        {
            MapEntity? entity = await _dbContext.Maps
            .FirstOrDefaultAsync(e => e.MapId == GameId);
            return entity is null ? null : new MapDetail
            {
                MapType = entity.MapType,
                MapName = entity.MapName,
                MapDescription = entity.MapDescription,
                PrecipitationType = entity.PrecipitationType

            };
        }
        public async Task<IEnumerable<MapListItem>> GetAllMapsAsync()
        {
            List<MapListItem> maps = await _dbContext.Maps
                .Select(entity => new MapListItem
                {
                    MapId = entity.MapId,
                    GameId = entity.GameId,
                    MapName = entity.MapName,
                    MapType = entity.MapType,
                    MapDescription = entity.MapDescription,
                    PrecipitationType = entity.PrecipitationType
                })
                .ToListAsync();
            return maps;        
        }


        public async Task<bool> UpdateMapAsync(MapUpdate request)
        {
            MapEntity? entity = await _dbContext.Maps.FindAsync(request.MapId);
            if (entity == null)
                return false;

            entity.MapId = request.MapId;
            entity.GameId = request.GameId;
            entity.MapType = request.MapType;
            entity.MapName = request.MapName;
            entity.MapDescription = request.MapDescription;
            entity.IsDayTime = request.IsDayTime;
            entity.PrecipitationType = request.PrecipitationType;

            int numberOfChanges = await _dbContext.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        Task<MapListItem?> IMapGenerator.CreateMapAsync(MapCreate request)
        {
            throw new NotImplementedException();
        }
    }
}
