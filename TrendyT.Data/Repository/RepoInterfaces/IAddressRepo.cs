using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyT.Data.Entities;

namespace TrendyT.Data.Repository.RepoInterfaces
{
    public interface IAddressRepo
    {
        bool AddAddress(Address address);
    }
}
