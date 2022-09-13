using Gamechain.Domain.Entities.Common;

namespace Gamechain.Application.Contracts.Interfaces.Repositories
{
    public interface IRepository<T> where T : AggregateRoot
    {
        Task<List<T>> GetAll();
        Task<T?> GetById(Guid id);
        Task<T> Create(T entity);
    }
}
