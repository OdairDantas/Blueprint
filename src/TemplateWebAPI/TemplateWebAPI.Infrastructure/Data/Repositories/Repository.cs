﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TemplateWebAPI.Domain.DomainObjects.Interfaces;
using TemplateWebAPI.Domain.DomainObjects;
using TemplateWebAPI.Domain.Repositories;
using $safeprojectname$.Data.Contexts;

namespace $safeprojectname$.Data.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : Entity, IAggregateRoot
    {

        public IUnitOfWork UnitOfWork => _context;
        private readonly BaseDbContext _context;
        private readonly DbSet<T> _repo;

        protected Repository(BaseDbContext context)
        {
            _context = context;
            _repo = _context.Set<T>();

        }
        public async Task Adicionar(T entity)
        {
            await Task.Run(() => _repo.Add(entity));
        }

        public async Task Atualizar(T entity)
        {
            await Task.Run(() => _repo.Update(entity));
        }

        public async Task<T> ObterPorId(Guid id)
        {
            return await _repo.FindAsync(id);
        }
        public async Task<T> ObterPorId(int id)
        {
            return await _repo.FindAsync(id);
        }

        public async Task<IEnumerable<T>> ObterTodos()
        {
            return await _repo.ToListAsync();
        }

        public async Task<IEnumerable<T>> ObterPor(Expression<Func<T, bool>> predicate)
        {
            return await _repo.Where(predicate).AsNoTracking().ToListAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
