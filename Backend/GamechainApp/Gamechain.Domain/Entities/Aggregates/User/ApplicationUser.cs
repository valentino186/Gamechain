using Microsoft.AspNetCore.Identity;

namespace Gamechain.Domain.Entities.Aggregates.User
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ApplicationUser(string userName, string email, string firstName, string lastName)
        {
            UserName = userName;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }

        public ApplicationUser(Guid id, string userName, string email, string firstName, string lastName) : this(userName, email, firstName, lastName)
        {
            Id = id;
        }
    }
}
