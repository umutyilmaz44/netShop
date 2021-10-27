using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using netShop.Domain.Common;
using netShop.Application.Wrappers;
using netShop.Application.Interfaces.Repository.Extensions;

namespace netShop.Application.Interfaces.Repository.Base {
    public interface IRepository<T> where T : BaseEntity {
        Task<IReadOnlyList<T>> GetAllAsync ();

        Task<PagedResponse<IEnumerable<T>>> FindAsync (Expression<Func<T, bool>> filter=null, 
                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,  
                                        Func<IIncludable<T>, IIncludable> includes = null, 
                                        int? pageIndex=null, int? pageSize=null);
        Task<T> GetByIdAsync (Guid id);
        Task<T> AddAsync (T entity);
        Task AddRangeAsync (IEnumerable<T> entities);
        Task UpdateAsync (T entity);
        Task DeleteAsync (T entity);

        Task DeleteRangeAsync (IEnumerable<T> entities);
        
    }
}