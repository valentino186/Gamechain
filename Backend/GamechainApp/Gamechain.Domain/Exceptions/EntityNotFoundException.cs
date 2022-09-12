namespace Gamechain.Domain.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(Type entityType) : base($"{entityType.Name} not found.")
        {
        }
    }
}
