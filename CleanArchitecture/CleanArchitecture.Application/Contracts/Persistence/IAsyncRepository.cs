using CleanArchitecture.Domain.Common;
using System.Linq.Expressions;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : BaseDomainModel
    {
        // Metodos genericos para obtener la data de la BD
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                        string includeString = null,
                        bool disableTracking = true);
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                List<Expression<Func<T,object>>> includes = null,
                bool disableTracking = true);
        Task<T> GetByIdAsync(int id);

        // Metodos para manipular la Data. Actualizar, Agregar o eliminar
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
