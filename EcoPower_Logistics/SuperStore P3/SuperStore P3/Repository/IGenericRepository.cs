using System.Collections.Generic;
using System.Linq.Expressions;

namespace EcoPower_Logistics.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Remove(T entity);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);

        void AddRange(IEnumerable<T> entities);
    }
}
