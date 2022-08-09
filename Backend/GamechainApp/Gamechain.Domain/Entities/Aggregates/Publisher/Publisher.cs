using Gamechain.Domain.Entities.Common;

namespace Gamechain.Domain.Entities.Aggregates.PublisherAggregate
{
    public class Publisher : AggregateRoot
    {
        public string Name { get; set; }
        public IList<Game> Games { get; set; }

        public Publisher(string name)
        {
            Name = name;
            Games = new List<Game>();
        }

        public Publisher(Guid id, string name): this(name)
        {
            Id = id;
        }
    }
}
