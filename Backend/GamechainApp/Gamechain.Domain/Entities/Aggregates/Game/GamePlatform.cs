using Gamechain.Domain.Entities.Common;

namespace Gamechain.Domain.Entities.Aggregates.Game
{
    public class GamePlatform
    {
        public Guid GameId { get; set; }
        public Guid PlatformId { get; set; }

        public GamePlatform(Guid gameId, Guid platformId)
        {
            GameId = gameId;
            PlatformId = platformId;
        }
    }
}
