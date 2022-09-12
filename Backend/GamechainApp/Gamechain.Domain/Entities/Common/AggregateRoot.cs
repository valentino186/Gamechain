namespace Gamechain.Domain.Entities.Common
{
    public abstract class AggregateRoot
    {
        public Guid Id { get; set; }
    }
}
