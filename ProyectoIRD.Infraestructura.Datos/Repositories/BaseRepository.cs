using Microsoft.EntityFrameworkCore;
using ProyectoIRD.Dominio.Entities;
using ProyectoIRD.Dominio.Interfaces;
using ProyectoIRD.Infraestructura.Datos.Data;

namespace ProyectoIRD.Infraestructura.Datos.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly MapaIRDContext _context;
        protected readonly DbSet<T> _entities;

        public BaseRepository(MapaIRDContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public async Task Add(T entity)
        {
           await _entities.AddAsync(entity);

        }

        public IEnumerable<T> GetAll()
        {
            return  _entities.AsEnumerable();
        }

        public async Task<T> GetById(Guid id)
        {
            var entity = await _entities.FindAsync(id);
            return entity!;
        }

        public void Update(T entity)
        {
            _entities.Update(entity);

        }

        public async Task Delete(Guid id)
        {
            T entity = await GetById(id);
            _entities.Remove(entity);
        }
    }
}
