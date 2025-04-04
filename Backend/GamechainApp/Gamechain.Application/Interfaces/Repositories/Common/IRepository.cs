﻿using Gamechain.Domain.Entities.Common;

namespace Gamechain.Application.Interfaces.Repositories.Common
{
    public interface IRepository<T> where T : AggregateRoot
    {
        Task<List<T>> GetAll();
        Task<T?> GetById(Guid id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task Delete(T entity);
    }
}
