using Gamechain.Domain.Entities.Common;

namespace Gamechain.Domain.Entities.Aggregates.Cart
{
    public class GameCart : Entity
    {
        public Guid CartId { get; set; }
        public Guid GameId { get; set; }
    }
}
