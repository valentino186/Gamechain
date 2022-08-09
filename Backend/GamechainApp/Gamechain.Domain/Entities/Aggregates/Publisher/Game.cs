using Gamechain.Domain.Entities.Common;

namespace Gamechain.Domain.Entities.Aggregates.PublisherAggregate
{
    public class Game : Entity
    {
        public Guid PublisherId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public double Discount { get; set; }
    }
}
