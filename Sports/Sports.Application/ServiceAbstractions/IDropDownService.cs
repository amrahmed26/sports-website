using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Application.ServiceAbstractions
{
    public interface IDropDownService
    {
        Task<object> GetDropDownAsync<T>(Expression<Func<T, object>> selector, Expression<Func<T, bool>>? filter) where T : class;
        object GetDropDown<T>(Expression<Func<T, object>> selector, Expression<Func<T, bool>>? filter) where T : class;
    }
}
