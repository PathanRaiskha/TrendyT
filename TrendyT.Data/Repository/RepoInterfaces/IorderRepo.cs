using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyT.Data.Entities;
using TrendyT.DTO;

namespace TrendyT.Data.Repository.RepoInterfaces
{
    public  interface IorderRepo
    {
        Task<List<Order>> GetAllOrder();
        //Task<PagedReesult<List<OrderDTO>>> GetOrderPagedAsync(int pageIndex = 0, int pageSize = 10, string orderBy = "", bool orderByAsc = true, string searchTerm = "");

    }
}
