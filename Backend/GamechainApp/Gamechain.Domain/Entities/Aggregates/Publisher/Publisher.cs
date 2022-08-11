using Gamechain.Domain.Entities.Common;

namespace Gamechain.Domain.Entities.Aggregates.Publisher
{
    public class Publisher : AggregateRoot
    {
        public string Name { get; set; }

        public Publisher(string name)
        {
            Name = name;
        }

        public Publisher(Guid id, string name): this(name)
        {
            Id = id;
        }
    }
}
