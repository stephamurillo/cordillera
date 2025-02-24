using KeraNaidi.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KeraNaidi.Interfaces
{
    public interface IUbicacionService
    {
        Task<IEnumerable<Ubicacion>> GetAllAsync();
        Task<Ubicacion> GetByIdAsync(int id);
        Task AddAsync(Ubicacion ubicacion);
        Task<Ubicacion> UpdateAsync(Ubicacion ubicacion);
        Task<bool> DeleteAsync(int id);
    }
}
