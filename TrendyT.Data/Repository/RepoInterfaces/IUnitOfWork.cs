using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendyT.Data.Repository.RepoInterfaces
{
    public interface IUnitOfWork
    {
       
        IUserRepo UserRepo { get; }
        IProductRepo ProductRepo { get; }
        IorderRepo OrderRepo { get; }
        
        Task<string> save();
    }
}
