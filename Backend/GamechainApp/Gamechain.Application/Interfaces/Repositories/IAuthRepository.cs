using Gamechain.Domain.Entities.Aggregates.User;

namespace Gamechain.Application.Interfaces.Repositories
{
    public interface IAuthRepository
    {
        string GetToken(ApplicationUser user);
    }
}
