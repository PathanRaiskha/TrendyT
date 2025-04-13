using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyT.DTO;

namespace TrendyT.Services.Interfaces
{
    public interface IProductService
    {
        Task<ApiResponse> AddProduct(ProductDTO productDTO);
        Task<ApiResponse> DeleteProduct(string productId);
        Task<ApiResponse> UpdateProduct(ProductDTO p);
        Task<ApiResponse> UploadProductImages(ProductImageDTO productImageDTO);
        Task<ApiResponse> GetAllProducts(string HostUrl);
        Task<ApiResponse> GetProductsPagedAsync(int pageIndex = 0, int pageSize = 10, string orderBy = "", bool orderByAsc = true, string searchTerm = "");
    }
}
