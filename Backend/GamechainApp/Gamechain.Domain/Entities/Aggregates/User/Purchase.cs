using Gamechain.Domain.Entities.Common;

namespace Gamechain.Domain.Entities.Aggregates.User
{
    public class Purchase : Entity
    {
        public Guid UserId { get; set; }
        public Guid GameId { get; set; }

        public DateTime PurchaseDate { get; set; }
        public DateTime? RefundDate { get; set; }
    }
}
