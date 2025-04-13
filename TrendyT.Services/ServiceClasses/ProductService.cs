using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TrendyT.Data.Entities;
using TrendyT.Data.Repository.RepoInterfaces;
using TrendyT.DTO;
using TrendyT.Services.Interfaces;

namespace TrendyT.Services.ServiceClasses
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async  Task<ApiResponse> AddProduct(ProductDTO productDTO)
        {
            ApiResponse apiResponse = new ApiResponse();
            Product productEntity= _mapper.Map<Product>(productDTO);
            var isAdded=await _uow.ProductRepo.AddProduct(productEntity);
            if (isAdded)
            {
                string isSaved = await _uow.save();
                bool tryParseResult;
                apiResponse=(Boolean.TryParse(isSaved, out tryParseResult) && tryParseResult)? new ApiResponse(productEntity.Id.ToString(), HttpStatusCode.Created.ToString(), true) : new ApiResponse(null, isSaved, false);
            }
            
            return apiResponse;

        }

        public async Task<ApiResponse> UploadProductImages(ProductImageDTO productImageDTO)
        {
            ApiResponse apiResponse = new ApiResponse();


            try
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ProductImages/" + productImageDTO.ProductId);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                FileInfo fileInfo = new FileInfo(productImageDTO.FrontImage.FileName);
                //string fileName = productImageDTO.FrontImage.FileName + fileInfo.Extension;
                string fileName = productImageDTO.ProductId+ "FrontImage" + fileInfo.Extension;
                string fileNameWithPath = Path.Combine(path, fileName);

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    productImageDTO.FrontImage.CopyTo(stream);
                }

                 fileInfo = new FileInfo(productImageDTO.BackImage.FileName);
                 fileName = productImageDTO.ProductId + "BackImage" + fileInfo.Extension;
                 fileNameWithPath = Path.Combine(path, fileName);

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    productImageDTO.BackImage.CopyTo(stream);
                }

                 fileInfo = new FileInfo(productImageDTO.LeftImage.FileName);
                 fileName = productImageDTO.ProductId + "LeftImage" + fileInfo.Extension;
                 fileNameWithPath = Path.Combine(path, fileName);

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    productImageDTO.LeftImage.CopyTo(stream);
                }

                 fileInfo = new FileInfo(productImageDTO.RightImage.FileName);
                 fileName = productImageDTO.ProductId + "RightImage" + fileInfo.Extension;
                 fileNameWithPath = Path.Combine(path, fileName);

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    productImageDTO.RightImage.CopyTo(stream);
                }
                apiResponse = new ApiResponse(null, "File Upoaded Successfully....", true);

            }
            catch (Exception ee)
            {
                apiResponse = new ApiResponse(null, ee.Message, false);
            }

            return apiResponse;

        }
        
        public async Task<ApiResponse> GetAllProducts(string HostUrl)
        {
            ApiResponse apiResponse = new ApiResponse();
            var result = await _uow.ProductRepo.GetAllProducts();
            var productData= _mapper.Map<List<ProductDTO>>(result);
            string commonPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\ProductImages\\");
            

            productData.ForEach(item => {
                var fileList = Directory.GetFiles(commonPath+item.Id);
                var FrontImageFileName = "";
                var BackImageFileName = "";
                var LeftImageFileName = "";
                var RightImageFileName = "";
                fileList.ToList().ForEach(x => {
                    var fileName = x.Substring(x.LastIndexOf($"\\") + 1);
                    if (fileName.Contains("FrontImage"))
                    {
                        FrontImageFileName = fileName;
                    }
                    if (fileName.Contains("BackImage"))
                    {
                        BackImageFileName = fileName;
                    }
                    if (fileName.Contains("LeftImage"))
                    {
                        LeftImageFileName = fileName;
                    }
                    if (fileName.Contains("RightImage"))
                    {
                        RightImageFileName = fileName;
                    }

                });


                item.ProductDetail.FrontImage = $"{HostUrl}{item.Id}/{FrontImageFileName}";
                item.ProductDetail.BackImage = $"{HostUrl}{item.Id}/{BackImageFileName}";
                item.ProductDetail.LeftImage = $"{HostUrl}{item.Id}/{LeftImageFileName}";
                item.ProductDetail.RightImage = $"{HostUrl}{item.Id}/{RightImageFileName}";
            });

            if (result.Count > 0)
            {
                apiResponse = new ApiResponse(productData, "", true);
            }
            return apiResponse;

        }
        public async Task<ApiResponse> GetProductsPagedAsync(int pageIndex = 0, int pageSize = 10, string orderBy = "", bool orderByAsc = true, string searchTerm = "")
        {
            ApiResponse apiResponse = new ApiResponse();
            var pagedResult = await _uow.ProductRepo.GetProductsPagedAsync(pageIndex, pageSize, orderBy, orderByAsc, searchTerm);
            apiResponse = new ApiResponse(pagedResult.Result, pagedResult.TotalRecords.ToString(), true);
            return apiResponse;
        }
        public async Task<ApiResponse> DeleteProduct(string productId)
        {
            ApiResponse apiResponse = new ApiResponse();
            var result = await _uow.ProductRepo.DeleteProduct(productId);
            if (result)
                apiResponse = new ApiResponse(null, "", true);
            return apiResponse;


        }
        public async Task<ApiResponse> UpdateProduct(ProductDTO p)
        {
            ApiResponse apiResponse = new ApiResponse();
            Product pp = _mapper.Map<Product>(p);

            await _uow.ProductRepo.UpdateProduct(pp);
            string isSaved = await _uow.save();
            bool tryParseResult;
            apiResponse = (Boolean.TryParse(isSaved, out tryParseResult) && tryParseResult) ? new ApiResponse(pp.Id.ToString(), HttpStatusCode.Created.ToString(), true) : new ApiResponse(null, isSaved, false);

            return apiResponse;

        }



        


    }
}
