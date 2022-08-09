using Gamechain.Domain.Entities.Common;

namespace Gamechain.Domain.Entities.Aggregates.Platform
{
    public class Platform : AggregateRoot
    {
        public string Name { get; set; }

        public Platform(string name)
        {
            Name = name;
        }

        public Platform(Guid id, string name): this(name)
        {
            Id = id;
        }
    }
}
