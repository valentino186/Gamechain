namespace Gamechain.Domain.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        private const string ExceptionCode = "App:0001";

        public EntityNotFoundException(Type entityType) : base($"{ExceptionCode} - {entityType.Name} not found.")
        {
        }
    }
}
