using Gamechain.Domain.Entities.Common;
using Gamechain.Domain.Exceptions;

namespace Gamechain.Domain.Entities.Aggregates.Feature
{
    public class Feature : AggregateRoot
    {
        public string Name { get; set; }

        public Feature(string name)
        {
            Name = name;    
        }

        public Feature(Guid id, string name): this(name)
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
