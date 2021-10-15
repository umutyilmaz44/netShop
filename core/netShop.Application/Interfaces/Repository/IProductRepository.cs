using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using netShop.Application.Interfaces.Repository.Base;
using netShop.Domain.Entities;

namespace netShop.Application.Interfaces.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        //custom operations here
        Task<IEnumerable<Product>> GetProductByCode(string code);
    }

}