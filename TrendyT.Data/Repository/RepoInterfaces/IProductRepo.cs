using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyT.Data.Entities;

namespace TrendyT.Data.Repository.RepoInterfaces
{
    public interface IProductRepo
    {
        Task<bool> AddProduct(Product product);
        Task<bool> DeleteProduct(string productId);
        Task<bool> UpdateProduct(Product product);
        Task<List<Product>> GetAllProducts();
        Task<PagedReesult<List<Product>>> GetProductsPagedAsync(int pageIndex = 0, int pageSize = 10, string orderBy = "", bool orderByAsc = true, string searchTerm = "");
    }
}
