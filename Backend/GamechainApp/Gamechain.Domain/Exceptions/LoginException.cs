namespace Gamechain.Domain.Exceptions
{
    public class LoginException : Exception
    {
        public LoginException() : base("Incorrect username or password.")
        {
        }
    }
}
