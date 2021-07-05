using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using $safeprojectname$.DomainObjects;

namespace $safeprojectname$.Repositories
{

    public interface IMongoRepository<T> where T : Entity
    {
        Task<IEnumerable<T>> ObterTodos();
        Task<T> ObterPorId(Guid id);
        Task Adicionar(T entity);
        Task Atualizar(T entity);
        Task<IEnumerable<T>> ObterPor(Expression<Func<T, bool>> predicate);
    }

}
