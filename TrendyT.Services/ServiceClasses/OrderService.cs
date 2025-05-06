using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyT.Data;
using TrendyT.Data.Entities;
using TrendyT.Data.Repository.RepoInterfaces;
using TrendyT.DTO;
using TrendyT.Services.Interfaces;

namespace TrendyT.Services.ServiceClasses
{
    internal class OrderService:IOrderServices
    {

       




       

        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public OrderService( IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
           
        }

        public async Task<ApiResponse> GetAllOrder()
        {
             var ListOfAllOrders=await _uow.OrderRepo.GetAllOrder();
            return new ApiResponse { IsSuccess = true, Message = "list is fethched succesfully", Result = ListOfAllOrders };

            
               
                //res.ForEach(res => res.Address.User = null);
            //    if(res.Count > 0)
            //{
            //    return new ApiResponse { Message = "this your order list", IsSuccess = true, Result = res };

            //}
            //else
            //{
            //    return new ApiResponse { IsSuccess=false, Message="order list is empty ", Result = null };
            //}

                
            

            //var result = _context.Orders.;
            //if (result.Count > 0)
            //{
            //    apiResponse = new ApiResponse(result, "", true);
            //}
            //return apiResponse;

        }

        //public async Task<ApiResponse> GetUsersPagedAsync(int pageIndex = 0, int pageSize = 10, string orderBy = "", bool orderByAsc = true, string searchTerm = "")
        //{
        //    ApiResponse apiResponse = new ApiResponse();
        //    var pagedResult = await _uow.UserRepo.GetUsersPagedAsync(pageIndex, pageSize, orderBy, orderByAsc, searchTerm);
        //    apiResponse = new ApiResponse(pagedResult.Result, pagedResult.TotalRecords.ToString(), true);
        //    return apiResponse;
        //}
    }
}
