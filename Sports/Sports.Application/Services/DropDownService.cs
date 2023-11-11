
using Microsoft.EntityFrameworkCore;
using Sports.Application.ServiceAbstractions;
using Sports.Infastructure.DataContext;
using System.Linq.Expressions;

namespace Sports.Application.Services
{
   
    public class DropDownService:IDropDownService
    {
        private readonly SportsDbContext context;
        public DropDownService(SportsDbContext context)
        {
            this.context = context;
        }

        public object GetDropDown<T>(Expression<Func<T, object>> selector, Expression<Func<T, bool>>? filter) where T : class
        {
            if (selector != null && filter != null)
                return  context.Set<T>().Where(filter).Select(selector).AsNoTracking().Distinct().ToList();
            else if (selector != null)
                return  context.Set<T>().Select(selector).AsNoTracking().Distinct().ToList();
            else if (filter != null)
                return  context.Set<T>().Where(filter).AsNoTracking().Distinct().ToList();
            
                return  context.Set<T>().AsNoTracking().Distinct().ToList();
        }

        public async Task<object> GetDropDownAsync<T>(Expression<Func<T, object>> selector, Expression<Func<T, bool>>? filter) where T : class 
        {
            if (selector != null && filter != null)
                return await context.Set<T>().Where(filter).Select(selector).AsNoTracking().Distinct().ToListAsync();
            else if (selector != null)
                return await context.Set<T>().Select(selector).AsNoTracking().Distinct().ToListAsync();
            else if (filter != null)
                return await context.Set<T>().Where(filter).AsNoTracking().Distinct().ToListAsync();
            else
                return await context.Set<T>().AsNoTracking().Distinct().ToListAsync();
        }


    }
}
