using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnDTeamGame.Data.Entities;
using DnDTeamGame.Models.MapModels;

namespace DnDTeamGame.Services.MapServices;
public interface IMapGenerator
{
    Task<MapListItem?> CreateMapAsync(MapCreate request);
    Task<IEnumerable<MapListItem>> GetAllMapsAsync();
    Task<MapDetail> GetMapByGameIdAsync(int GameId);
    Task<bool> UpdateMapAsync(MapUpdate request);
    Task<bool> DeleteMapAsync(int MapId);

}

