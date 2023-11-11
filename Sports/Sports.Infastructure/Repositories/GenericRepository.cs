using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sports.Domain.Abstractions;
using Sports.Infastructure.DataContext;
using Sports.Infastructure.Extensions;
using System.Linq.Expressions;

namespace Sports.Infastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly SportsDbContext _context;
        internal DbSet<T> _entity;
        protected Sports.Infastructure.DapperORM.DapperORM dapper; 
        protected readonly IMapper mapper;
        public GenericRepository(SportsDbContext context,IMapper mapper)
        {
            _context = context;
            _entity = context.Set<T>();
            dapper = DapperORM.DapperORM.dapperInstance;
            this.mapper = mapper;   
        }

        public async Task Add(T entity) => await _entity.AddAsync(entity);
        public async Task AddRange(IEnumerable<T> entities) => await _entity.AddRangeAsync(entities);
        public void Update(T entity) => _context.Entry<T>(entity).State = EntityState.Modified;
        public void Update<TSource>(TSource entityDTO) where TSource : class
        {
            var entity=mapper.Map<T>(entityDTO);    
            _context.Entry<T>(entity).State = EntityState.Modified;
        }
        public async Task UpdateAsync<TSource>(TSource entityDTO) where TSource : class
        {
            var entity=mapper.Map<T>(entityDTO);    
            _context.Entry<T>(entity).State = EntityState.Modified;
        }
        public void Delete(T entity) => _context.Entry<T>(entity).State = EntityState.Deleted;
        public async Task<T?> GetById(int id) => await _entity.FindAsync(id);
        public async Task<T?> GetByGuid(Guid id) => await _entity.FindAsync(id);
        public async Task<T?> GetObj(Expression<Func<T, bool>> filter) => await _entity.AsQueryable<T>().FirstOrDefaultAsync(filter);
        public async Task<bool> IsExist(Expression<Func<T, bool>> filter) => await _entity.AnyAsync(filter);
        public async Task<bool> Save() => await _context.SaveChangesAsync() > 0;
        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.Where(criteria).ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int take, int skip)
        {
            return await _context.Set<T>().Where(criteria).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int? take, int? skip,
            Expression<Func<T, object>> orderBy = null, string orderByDirection = "Ascending")
        {
            IQueryable<T> query = _context.Set<T>().Where(criteria);

            if (take.HasValue)
                query = query.Take(take.Value);

            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (orderBy != null)
            {
                if (orderByDirection == "Ascending")
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }

            return await query.ToListAsync();
        }

        public T Add<TSource>(TSource entityDTO) where TSource : class
        {
            var entity = mapper.Map<T>(entityDTO);
            _context.Set<T>().Add(entity);
            return entity;
        }

        public async Task<T> AddAsync<TSource>(TSource entityDTO) where TSource : class
        {
            var entity = mapper.Map<T>(entityDTO);
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<T?> GetObjWithInclude(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (Expression<Func<T, object>> include in includes)
                query = query.Include(include);

            return query.FirstOrDefault(filter)!;
        }

        public int Delete(int Id)
        {

            return   _context.Database.ExecuteSqlRaw($"Delete From  {_context.GetTableName<T>()} where {_context.GetPrimaryKeyColumnName<T>()}={Id}");
        }

        public async Task<object> GetObj(Expression<Func<T, object>> selector, Expression<Func<T, bool>>? filter)
        {
            return await _context.Set<T>().Where(filter).Select(selector).FirstOrDefaultAsync();
        }     
        public async Task<object> GetObjs(Expression<Func<T, object>> selector)
        {
            return await _context.Set<T>().Select(selector).ToListAsync();
        }

        public async Task<object> FindAllAsync(Expression<Func<T, object>> Selector, Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.Where(criteria).Select(Selector).ToListAsync();
        }

        public async Task<object> FindAllAsync(Expression<Func<T, object>> Selector, Expression<Func<T, bool>> criteria, int take, int skip)=>
             await _context.Set<T>().Where(criteria).Select(Selector).Skip(skip).Take(take).ToListAsync();

        public void Update(string Query)
        {
           _context.Database.ExecuteSqlRaw(Query);
        }

        public async Task<object> GetObjs(Expression<Func<T, object>> selector, Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().Where(filter).Select(selector).ToListAsync();
        }
        public  async Task<object> SqlRaw(string Query)
        {
            return await  _context.Set<T>().FromSqlRaw(Query).ToListAsync();
        }

        public async Task<List<TOut>> GetDataByDapper<TOut>(string Query) where TOut : class
        {
            return  await dapper.GetDataAsync<TOut>(Query);
        }
        public async Task<List<T>> GetAll() =>await _context.Set<T>().ToListAsync();    
    }
}
