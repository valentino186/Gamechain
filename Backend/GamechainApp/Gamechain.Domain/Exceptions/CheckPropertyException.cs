namespace Gamechain.Domain.Exceptions
{
    public class CheckPropertyException : Exception
    {
        private const string ExceptionCode = "App:0002";

        public CheckPropertyException(string propertyName) : base($"{ExceptionCode} - {propertyName} can not be empty.")
        {
        }
    }
}
