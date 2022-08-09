using Gamechain.Domain.Entities.Common;

namespace Gamechain.Domain.Entities.Aggregates.GenreAggregate
{
    public class Genre : AggregateRoot
    {
        public string Name { get; set; }

        public Genre(string name)
        {
            Name = name;    
        }

        public Genre(Guid id, string name): this(name)
        {
            Id = id;
        }
    }
}
