namespace Gamechain.Domain.Entities.Aggregates.Game
{
    public class GameFeature
    {
        public Guid GameId { get; set; }
        public Guid FeatureId { get; set; }

        public GameFeature(Guid gameId, Guid featureId)
        {
            GameId = gameId;
            FeatureId = featureId;
        }
    }
}
