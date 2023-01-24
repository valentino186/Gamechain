using Gamechain.Domain.Entities.Common;
using Gamechain.Domain.Exceptions;

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

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new CheckPropertyException(nameof(Name));
            }

            Name = name;
        }
    }
}
