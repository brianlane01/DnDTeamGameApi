using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnDTeamGame.Models.Games;

namespace DnDTeamGame.Services.Games
{
    public interface IGameService
    {
        Task<GamesListItem> CreateGameAsync(GameCreate model);

        Task<GameDetails?> GetGameByIdAsync(int gameId);

        Task<IEnumerable<GamesListItem>> GetAllGamesAsync();

        Task<bool> UpdateGamesAsync(GameUpdate request);

        Task<bool> DeleteDameAsync(int gameId);
    }
}