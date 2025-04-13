using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyT.Data.Entities;
using TrendyT.Data.Repository.RepoInterfaces;

namespace TrendyT.Data.Repository.Repos
{
    public class AddressRepository : IAddressRepo
    {
        private readonly ApplicationDbContext _context;
        public AddressRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool AddAddress(Address address)
        {
             _context.Addresses.Add(address);
            return true;
            
        }
    }
}
