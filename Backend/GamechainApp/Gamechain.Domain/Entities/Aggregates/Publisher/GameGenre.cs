using Gamechain.Domain.Entities.Common;

namespace Gamechain.Domain.Entities.Aggregates.Publisher
{
    public class GameGenre : Entity
    {
        public Guid GameId { get; set; }
        public Guid GenreId { get; set; }
    }
}
