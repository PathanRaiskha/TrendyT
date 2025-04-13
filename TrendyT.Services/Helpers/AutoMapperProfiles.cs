using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyT.Data.Entities;
using TrendyT.DTO;

namespace TrendyT.Services.Helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ApplicationUser,UserDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<OrderedProducts, OrderedProductsDTO>().ReverseMap();
            CreateMap<ProductDetail, ProductDetailDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Review, ReviewDTO>().ReverseMap();




        }
    }
}
