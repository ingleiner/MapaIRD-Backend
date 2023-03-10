using ProyectoIRD.Dominio.Entities;

namespace ProyectoIRD.Dominio.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(Guid id);
        Task Add(T entity);
        void Update(T entity);    
        Task Delete(Guid id);
    }
}
