using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using TrendyT.DTO;
using TrendyT.Services.Interfaces;
using TrendyT.Services.ServiceClasses;

namespace TrendyT.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService= productService;
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<ApiResponse> UploadProductImages([FromForm] ProductImageDTO productImageDTO)
        {

            var result = await _productService.UploadProductImages(productImageDTO);
            return result;
        }
        [HttpPost]
        public async Task<ApiResponse> Product([FromBody] ProductDTO productDTO)
        {
            var result = await _productService.AddProduct(productDTO);
            return result;
        }
        [HttpDelete]
        public async Task<ApiResponse> Product([FromQuery] string productId)
        {

            return await _productService.DeleteProduct(productId);
        }
        [HttpGet]
        public async Task<ApiResponse> GetAllProducts()
        {
            string hostUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/ProductImages/";
            var result = await _productService.GetAllProducts(hostUrl);
            return result;
        }
        [HttpGet]
        public async Task<ApiResponse> GetProductsPagedAsync(int pageIndex = 0, int pageSize = 10, string orderBy = "", bool orderByAsc = true, string searchTerm = "")
        {
            var result = await _productService.GetProductsPagedAsync(pageIndex, pageSize, orderBy, orderByAsc, searchTerm);
            return result;
        }
        [HttpPut]
        public async Task<ApiResponse> UpdateProduct([FromBody] ProductDTO productDTO)
        {
            var result = await _productService.UpdateProduct(productDTO);
            return result;
        }
        [HttpGet]
        public async Task<ApiResponse> GetProductImages([FromQuery] string productId)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {   
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\ProductImages\\" + productId + "\\");
                    var fileList = Directory.GetFiles(path);
                List<string> images = new List<string>();
                var hostUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/ProductImages/{productId}/";

                foreach (var file in fileList) {
                    images.Add(hostUrl+  file.Substring(file.LastIndexOf($"\\")+1));
                }
                    apiResponse=new ApiResponse(images, "",true);
            }
            catch (Exception ee)
            {
                apiResponse = new ApiResponse(null, ee.Message, false);

            }
            return apiResponse;

        }
        [HttpGet]
        public async Task<ApiResponse> GetCurrentWorkingDirectory()
        {
            var str = "";
            foreach (var item in Directory.GetFiles(Directory.GetCurrentDirectory()))
            {
                str=str+item;
            }
            var hostUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            //var aabb = _env.ContentRootPath;
            ApiResponse apiResponse = new ApiResponse(hostUrl, "", true);
            return apiResponse;
        }



    }
}
