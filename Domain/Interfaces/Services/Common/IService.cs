using Domain.Entities.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.Common
{
    public interface IService<TEntity> where TEntity : Entity
    {
        Task Add(TEntity entity);

        Task<TEntity> FindById(long id);

        Task<List<TEntity>> FindAll();

        Task Update(TEntity entity);

        Task Delete(long id);

    }
}
