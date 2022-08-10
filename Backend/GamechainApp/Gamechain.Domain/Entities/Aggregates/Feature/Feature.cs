using Gamechain.Domain.Entities.Common;

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
    }
}
