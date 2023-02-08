namespace Gamechain.Domain.Exceptions
{
    public class LoginException : Exception
    {
        private const string ExceptionCode = "App:0003";

        public LoginException() : base($"{ExceptionCode} - Incorrect username or password.")
        {
        }
    }
}
