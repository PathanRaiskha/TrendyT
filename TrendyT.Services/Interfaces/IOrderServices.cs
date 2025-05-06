using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyT.DTO;

namespace TrendyT.Services.Interfaces
{
    public interface IOrderServices
    {
        public Task<ApiResponse>GetAllOrder();
        //Task<ApiResponse> GetOrderPagedAsync(int pageIndex = 0, int pageSize = 10, string orderBy = "", bool orderByAsc = true, string searchTerm = "");

    }
}
