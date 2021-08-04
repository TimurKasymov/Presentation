using System.Collections.Generic;
using System.Threading.Tasks;

namespace Community2._0.BLL.Abstract
{
    public interface IService<TEntity> where TEntity : class
    {
        Task Create(TEntity entity);
        TEntity Get(int id);
        TEntity Get(string email, string password, bool emailOnly);
        List<TEntity> GetAllTracking();
        Task Update(TEntity entity);
        Task Delete(int id);
        Task CreateMany(List<TEntity> entities);
        public List<TEntity> GetAllNOTracking();
    }
}