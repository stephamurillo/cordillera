using KeraNaidi.Data.Models;
using KeraNaidi.Data;
using KeraNaidi.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KeraNaidi.Business.Services
{
    public class UbicacionService : IUbicacionService
    {
        private readonly IRepository<int, Ubicacion> _ubicacionRepository;

        public UbicacionService(IRepository<int, Ubicacion> ubicacionRepository)
        {
            _ubicacionRepository = ubicacionRepository;
        }

        public async Task<IEnumerable<Ubicacion>> GetAllAsync()
        {
            return await _ubicacionRepository.GetAllAsync();
        }

        public async Task<Ubicacion> GetByIdAsync(int id)
        {
            return await _ubicacionRepository.FindAsync(id);
        }

        public async Task AddAsync(Ubicacion ubicacion)
        {
            await _ubicacionRepository.AddAsync(ubicacion);
        }

        public async Task<Ubicacion> UpdateAsync(Ubicacion ubicacion)
        {
            await _ubicacionRepository.Update(ubicacion);
            return ubicacion;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var ubicacion = await _ubicacionRepository.FindAsync(id);
            if (ubicacion == null) return false;
            await _ubicacionRepository.Delete(id);
            return true;
        }
    }
}
