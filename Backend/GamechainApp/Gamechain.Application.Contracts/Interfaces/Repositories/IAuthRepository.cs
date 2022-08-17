using Gamechain.Domain.Entities.Aggregates.User;

namespace Gamechain.Application.Contracts.Interfaces.Repositories
{
    public interface IAuthRepository
    {
        string GetToken(ApplicationUser user);
    }
}
