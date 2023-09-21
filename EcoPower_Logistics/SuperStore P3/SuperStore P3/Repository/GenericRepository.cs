using Data;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace EcoPower_Logistics.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly SuperStoreContext _superStoreContext;

        public GenericRepository(SuperStoreContext superStoreContext)
        {
            _superStoreContext = superStoreContext;
        }

        public void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(Add)}must not be null");
            }
            try
            {
                _superStoreContext.Set<T>().Add(entity);
                _superStoreContext.SaveChanges();
            }
            catch (Exception ex) 
            {
                throw new Exception ($"{nameof(entity)} could not be saved:{ex.Message}");           
            }
        }

        public void Remove(T entity)
        {
            try
            {
                _superStoreContext.Set<T>().Remove(entity);
                _superStoreContext.SaveChanges();
            }
            catch (Exception ex) 
            {
                throw new Exception($"{nameof(entity)} could not be removed: {ex.Message}");
            }
        }

        public void AddRange(IEnumerable<T> entities)
        {
            try
            { 
                _superStoreContext.Set<T>().AddRange(entities);
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public  void RemoveRange(IEnumerable<T> entities)
        {
            try
            {
                _superStoreContext.RemoveRange(entities);
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return _superStoreContext.Set<T>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"No entities were found: {ex.Message}");
            }
        }

        public T GetById(int id)
        {
            try
            {
                return _superStoreContext.Set<T>().Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(id)} could not be found:{ex.Message}");
            }
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        { 
            try
            {
                return _superStoreContext.Set<T>().Where(expression);
            }
            catch (Exception ex) 
            {
                throw new Exception ($"Could not be found: {ex.Message}");
            }
        }
    }
}
