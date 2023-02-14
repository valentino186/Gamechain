using Gamechain.Domain.Entities.Common;

namespace Gamechain.Domain.Entities.Aggregates.Game
{
    public class GameGenre
    {
        public Guid GameId { get; set; }
        public Guid GenreId { get; set; }

        public GameGenre(Guid gameId, Guid genreId)
        {
            GameId = gameId;
            GenreId = genreId;
        }
    }
}
