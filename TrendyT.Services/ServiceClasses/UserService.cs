using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork uow, IMapper mapper) { 
            _uow = uow;
            _mapper = mapper;
        }
        

        public async Task<ApiResponse> AddUser(UserDTO u)
        {
            ApiResponse apiResponse = new ApiResponse();
            ApplicationUser uu=_mapper.Map<ApplicationUser>(u);

            var isAdded = await _uow.UserRepo.AddUser(uu);
            if (isAdded)
            {
                string isSaved = await _uow.save();
                bool tryParseResult;
                apiResponse = (Boolean.TryParse(isSaved, out tryParseResult) && tryParseResult) ? new ApiResponse(null, HttpStatusCode.Created.ToString(), true) : new ApiResponse(null, isSaved, false);
            }
            return apiResponse;

        }

        public async Task<ApiResponse> CheckLogin(string EmailId, string Password)
        {
            ApiResponse apiResponse = new ApiResponse(); 
            var result =await _uow.UserRepo.GetUser(EmailId, Password);
            if(result!=null)
            {
                var result1 = _mapper.Map<UserDTO>(result);
                apiResponse = new ApiResponse(result1, "", true);
            }
            return apiResponse;
        }
        public async Task<ApiResponse> GetAllUsers()
        { 
            ApiResponse apiResponse = new ApiResponse();
            var result = await _uow.UserRepo.GetAllUsers();
            if(result.Count>0)
            {
                apiResponse = new ApiResponse(result, "", true);
            }
            return apiResponse;

        }

        public async Task<ApiResponse> GetUsersPagedAsync(int pageIndex = 0, int pageSize = 10, string orderBy = "", bool orderByAsc = true, string searchTerm = "")
        {
            ApiResponse apiResponse = new ApiResponse();
            var pagedResult = await _uow.UserRepo.GetUsersPagedAsync(pageIndex, pageSize, orderBy, orderByAsc, searchTerm);
            apiResponse = new ApiResponse(pagedResult.Result, pagedResult.TotalRecords.ToString(), true);
            return apiResponse;
        }

        public async Task<ApiResponse> DeleteUser(string userId)
        {
            ApiResponse apiResponse = new ApiResponse();
            var result = await _uow.UserRepo.DeleteUser(userId);
            if(result)
                apiResponse = new ApiResponse(null,"",true);
            return apiResponse;


        }
        public async Task<ApiResponse> UpdateUser(UserDTO u)
        {
            ApiResponse apiResponse = new ApiResponse();
            ApplicationUser uu = _mapper.Map<ApplicationUser>(u);

            uu.Address.User = null;
            var rr=await _uow.UserRepo.UpdateUser(uu);
            string isSaved = await _uow.save();
            bool tryParseResult;
            apiResponse = (Boolean.TryParse(isSaved, out tryParseResult) && tryParseResult) ? new ApiResponse(uu.Id.ToString(), HttpStatusCode.Created.ToString(), true) : new ApiResponse(null, isSaved, false);
                   
            return apiResponse;

        }
    }
}
