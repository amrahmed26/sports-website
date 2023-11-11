
using System.Linq.Expressions;


namespace Sports.Domain.Abstractions
{
    public interface IGenericRepository<T> where T : class
    {

        Task Add(T entity);
        Task<List<TOut>> GetDataByDapper<TOut>(string Query) where TOut : class;

       Task<List<T>> GetAll();
        Task AddRange(IEnumerable<T> entities);
        Task<T?> GetById(int id);
        Task<T?> GetObj(Expression<Func<T, bool>> filter);
        Task<object> GetObj(Expression<Func<T, object>> selector, Expression<Func<T, bool>> filter);
        Task<object> GetObjs(Expression<Func<T, object>> selector);
        Task<object> GetObjs(Expression<Func<T, object>> selector, Expression<Func<T, bool>> filter);
        Task<T?> GetObjWithInclude(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);
        Task<bool> IsExist(Expression<Func<T, bool>> filter);
        void Delete(T entity);
        int Delete(int Id);
        void Update(T entity);
        void Update(string Query);
        void Update<TSource>(TSource entityDTO) where TSource : class;
        Task UpdateAsync<TSource>(TSource entityDTO) where TSource : class;
        Task<bool> Save();
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, string[] includes = null);
        Task<object> FindAllAsync(Expression<Func<T,object>> Selector,Expression<Func<T, bool>> criteria, string[] includes = null);
        Task<object> FindAllAsync(Expression<Func<T, object>> Selector, Expression<Func<T, bool>> criteria, int take, int skip);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int take, int skip);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int? take, int? skip,
            Expression<Func<T, object>> orderBy = null, string orderByDirection = "Ascending");   

        T Add<TSource>(TSource entityDTO) where TSource : class;
        Task<T> AddAsync<TSource>(TSource entityDTO) where TSource : class;
        Task<object> SqlRaw(string Query);
    }
}
