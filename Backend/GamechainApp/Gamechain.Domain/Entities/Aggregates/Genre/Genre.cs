using Gamechain.Domain.Entities.Common;
using Gamechain.Domain.Exceptions;

namespace Gamechain.Domain.Entities.Aggregates.Genre
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
