using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyT.Data.Entities;
using TrendyT.DTO;

namespace TrendyT.Data.Repository.RepoInterfaces
{
    public interface IUserRepo
    {
        Task<bool> AddUser(ApplicationUser user);
        Task<bool> DeleteUser(string userId);
        Task<ApplicationUser> GetUser(string EmailId, string Password);
        Task<List<ApplicationUser>> GetAllUsers();
        Task<PagedReesult<List<UserDTO>>> GetUsersPagedAsync(int pageIndex = 0, int pageSize = 10, string orderBy = "", bool orderByAsc = true, string searchTerm = "");
        Task<bool> UpdateUser(ApplicationUser user);
    }
}
