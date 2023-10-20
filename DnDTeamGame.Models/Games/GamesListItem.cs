namespace DnDTeamGame.Models.Games
{
    public class GamesListItem
    {
        public int GameId {get; set;}
        public string? GameName {get; set;}

        public string? GameDescription {get; set;}

        public int UserId {get; set;}

        public DateTimeOffset DateCreated {get; set;}
    }
}