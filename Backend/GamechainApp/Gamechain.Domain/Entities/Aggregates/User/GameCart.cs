using Gamechain.Domain.Entities.Common;

namespace Gamechain.Domain.Entities.Aggregates.User
{
    public class GameCart : Entity
    {
        public Guid CartId { get; set; }
        public Guid GameId { get; set; }
    }
}
