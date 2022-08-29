using Gamechain.Domain.Entities.Aggregates.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Gamechain.Infrastructure.EntityFrameworkCore.Context
{
    public static class GamechainDbContextExtensions
    {
        private const string adminUserGuid = "53bfb232-5070-4fcb-ba00-4ed5df35f6ff";
        private const string adminRoleGuid = "f2148693-2816-475e-8ad4-0bb2c4df685e";

        public static void SeedInitialData(this ModelBuilder builder)
        {
            Guid userGuid = Guid.Parse(adminUserGuid);
            Guid roleGuid = Guid.Parse(adminRoleGuid);

            builder.Entity<ApplicationRole>().HasData(
                new ApplicationRole
                {
                    Id = roleGuid,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
            );

            var passwordHasher = new PasswordHasher<ApplicationUser>();

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = userGuid,
                    UserName = "admin",
                    FirstName = "admin",
                    LastName = "admin",
                    NormalizedUserName = "ADMIN",
                    PasswordHash = passwordHasher.HashPassword(null, "123qwe")
                }
            );

            builder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>
                {
                    UserId = userGuid,
                    RoleId = roleGuid
                }
            );
        }
    }
}
