using DnDTeamGame.Data;
using DnDTeamGame.Data.Entities;
using DnDTeamGame.Models.Games;
using Microsoft.EntityFrameworkCore;

namespace DnDTeamGame.Services.Games
{
    public class GameService : IGameService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly int _userId;

        public GameService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GamesListItem> CreateGameAsync(GameCreate model)
        {
            GameEntity entity = new()
            {
                GameName = model.GameName,
                GameDescription = model.GameDescription,
                UserId = model.UserId,
                DateCreated = DateTimeOffset.Now

            };

            _dbContext.Games.Add(entity);
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            if (numberOfChanges != 1)
                return null;

            GamesListItem response = new()
            {
                GameId = entity.GameId,
                GameName = entity.GameName,
                GameDescription = entity.GameDescription,
                UserId = entity.UserId,
                DateCreated = DateTime.Now
            };

            return response;
        }

        public async Task<IEnumerable<GamesListItem>> GetAllGamesAsync()
        {
            List<GamesListItem> games = await _dbContext.Games
                .Select(entity => new GamesListItem
                {
                    GameId = entity.GameId,
                    GameName = entity.GameName,
                    GameDescription = entity.GameDescription,
                    UserId = entity.UserId,
                    DateCreated = entity.DateCreated
                })
                .ToListAsync();
            return games;
        }
        public async Task<GameDetails?> GetGameByIdAsync(int gameId)
        {
            GameEntity? entity = await _dbContext.Games
                .FindAsync(gameId);

            return entity is null ? null : new GameDetails
            {
                GameId = entity.GameId,
                GameName = entity.GameName,
                GameDescription = entity.GameDescription,
                UserId = entity.UserId,
                DateCreated = entity.DateCreated,
                DateModified = entity.DateModified
            };
        }

        public async Task<bool> UpdateGamesAsync(GameUpdate request)
        {
            GameEntity? entity = await _dbContext.Games.FindAsync(request.GameId);

            if(entity == null)
                return false;
            
            entity.GameId = request.GameId;
            entity.GameName = request.GameName;
            entity.GameDescription = request.GameDescription;
            entity.UserId = request.UserId;
            entity.DateModified = DateTimeOffset.Now;

            int numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteDameAsync(int gameId)
        {
            var gameEntity = await _dbContext.Games.FindAsync(gameId);

            if(gameEntity == null)
                return false;
            
            _dbContext.Games.Remove(gameEntity);
            
            return await _dbContext.SaveChangesAsync() ==1;

        }

    }
}