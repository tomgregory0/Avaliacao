using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Common
{
    public interface IRepository<TEntity>
    {
        Task Add(TEntity entity);

        Task<TEntity> FindById(long id);

        Task<List<TEntity>> FindAll();

        Task Update(TEntity entity);

        Task Delete(long id);

        Task<int> SaveChanges();
    }
}
