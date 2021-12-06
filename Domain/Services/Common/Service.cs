using Domain.Entities.Common;
using Domain.Interfaces.Common;
using Domain.Interfaces.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Services.Common
{
    public class Service<TEntity> : IService<TEntity> where TEntity : Entity
    {
        private readonly IRepository<TEntity> _repository;

        public Service(IRepository<TEntity> repository)
        {
            _repository = repository;
        }


        public async Task<TEntity> FindById(long id)
        {
            return await _repository.FindById(id);
        }

        public virtual async Task<List<TEntity>> FindAll()
        {
            return _repository.FindAll().Result
                .ToList();
        }

        public virtual async Task Add(TEntity entity)
        {
            await _repository.Add(entity);
        }

        public virtual async Task Update(TEntity entity)
        {
            await _repository.Update(entity);
        }

        public virtual async Task Delete(TEntity entity)
        {
            await _repository.Delete(entity);
        }

        public virtual async Task Salvar(TEntity entity)
        {
            try
            {
                await _repository.Update(entity);


            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
