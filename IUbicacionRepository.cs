using System.Collections.Generic;
using System.Threading.Tasks;
using KeraNaidi.Data.Models;

namespace KeraNaidi.Data.IRepository
{
    public interface IRepository<TId, TEntity>
        where TId : struct
        where TEntity : BaseEntity<TId>
    {
        Task AddAsync(TEntity entity);
        Task<TEntity> FindAsync(TId id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteAsync(TId id);
    }

    public interface IUbicacionRepository : IRepository<int, Ubicacion>
    {
        // Aquí puedes agregar métodos específicos para Ubicacion si es necesario
    }
}
