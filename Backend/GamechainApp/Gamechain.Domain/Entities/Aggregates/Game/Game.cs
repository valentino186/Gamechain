using Gamechain.Domain.Entities.Common;
using Gamechain.Domain.Exceptions;

namespace Gamechain.Domain.Entities.Aggregates.Game
{
    public class Game : AggregateRoot
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

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new CheckPropertyException(nameof(Name));
            }

            Name = name;
        }

        public void SetDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new CheckPropertyException(nameof(Description));
            }

            Description = description;
        }

        public void SetPrice(decimal price)
        {
            Price = price;
        }

        public void SetDiscount(double discount)
        {
            Discount = discount;
        }


        public void AddFeature(GameFeature gameFeature)
        {
            Features.Add(gameFeature);
        }

        public void SetFeatures(List<GameFeature> features)
        {
            Features = features;
        }

        public void AddGenre(GameGenre gameGenre)
        {
            Genres.Add(gameGenre);
        }

        public void SetGenres(List<GameGenre> genres)
        {
            Genres = genres;
        }

        public void AddPlatform(GamePlatform gamePlatform)
        {
            Platforms.Add(gamePlatform);
        }

        public void SetPlatforms(List<GamePlatform> platforms)
        {
            Platforms = platforms;
        }
    }
}
