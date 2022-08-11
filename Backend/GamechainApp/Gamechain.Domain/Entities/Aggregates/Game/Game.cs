using Gamechain.Domain.Entities.Common;

namespace Gamechain.Domain.Entities.Aggregates.Game
{
    public class Game : Entity
    {
        public Guid PublisherId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public double Discount { get; set; }

        public IList<GameFeature> Features { get; set; }
        public IList<GameGenre> Genres { get; set; }
        public IList<GamePlatform> Platforms { get; set; }

        public Game(Guid publisherId, string name, string description, decimal price, double discount)
        {
            PublisherId = publisherId;
            Name = name;
            Description = description;
            Price = price;
            Discount = discount;

            Features = new List<GameFeature>();
            Genres = new List<GameGenre>();
            Platforms = new List<GamePlatform>();
        }

        public Game(Guid id, Guid publisherId, string name, string description, decimal price, double discount) : this(publisherId, name, description, price, discount)
        {
            Id = id;
        }
    }
}
