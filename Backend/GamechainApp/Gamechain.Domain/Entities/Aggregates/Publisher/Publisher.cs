using Gamechain.Domain.Entities.Common;
using Gamechain.Domain.Exceptions;

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
