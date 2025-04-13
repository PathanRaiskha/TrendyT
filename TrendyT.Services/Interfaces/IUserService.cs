using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyT.Data.Entities;
using TrendyT.DTO;

namespace TrendyT.Services.Interfaces
{
    public interface IUserService
    {
        Task<ApiResponse> AddUser(UserDTO u);
        Task<ApiResponse> DeleteUser(string userId);
        Task<ApiResponse> CheckLogin(string EmailId, string Password);
        Task<ApiResponse> GetAllUsers();
        Task<ApiResponse> GetUsersPagedAsync(int pageIndex = 0, int pageSize = 10, string orderBy = "", bool orderByAsc = true, string searchTerm = "");
        Task<ApiResponse> UpdateUser(UserDTO u);
    }
}
