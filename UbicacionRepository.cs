using KeraNaidi.Data.IRepository;
using KeraNaidi.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KeraNaidi.Data.Repository
{
    public class Repository<TId, TEntity> : IRepository<TId, TEntity>
        where TId : struct
        where TEntity : BaseEntity<TId>
    {
        protected readonly KeraNaidiContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(KeraNaidiContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<TEntity> FindAsync(TId id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _dbSet.FindAsync(id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(TId id)
        {
            var entity = await FindAsync(id);
            if (entity != null)
            {
                await DeleteAsync(entity);
            }
        }

        public Task Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(TId id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }
    }

    public class UbicacionRepository : Repository<int, Ubicacion>, IUbicacionRepository
    {
        public UbicacionRepository(KeraNaidiContext context) : base(context)
        {
        }

        // Implementa métodos específicos para Ubicacion aquí si es necesario
    }
}
