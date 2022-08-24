using Gamechain.Domain.Entities.Common;

namespace Gamechain.Domain.Entities.Aggregates.Game
{
    public class GamePlatform
    {
        public Guid GameId { get; set; }
        public Guid PlatformId { get; set; }
    }
}
