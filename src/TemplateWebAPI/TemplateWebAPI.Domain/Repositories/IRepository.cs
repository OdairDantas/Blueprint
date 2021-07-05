﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using $safeprojectname$.DomainObjects.Interfaces;

namespace $safeprojectname$.Repositories
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        Task<IEnumerable<T>> ObterTodos();
        Task<T> ObterPorId(Guid id);
        Task<T> ObterPorId(int id);
        Task Adicionar(T entity);
        Task Atualizar(T entity);
        Task<IEnumerable<T>> ObterPor(Expression<Func<T, bool>> predicate);
        IUnitOfWork UnitOfWork { get; }

    }
}
