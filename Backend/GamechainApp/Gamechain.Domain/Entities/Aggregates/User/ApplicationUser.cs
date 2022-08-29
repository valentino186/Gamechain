using Microsoft.AspNetCore.Identity;

namespace Gamechain.Domain.Entities.Aggregates.User
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
