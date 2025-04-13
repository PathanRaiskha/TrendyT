using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyT.Data.Repository.RepoInterfaces;

namespace TrendyT.Data.Repository.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ApplicationDbContext context) { 
            _context = context;
        }
        private readonly ApplicationDbContext _context;

        public IUserRepo UserRepo => new UserRepository(_context);
        public IAddressRepo AddressRepo => new AddressRepository(_context);
        public IProductRepo ProductRepo =>  new ProductRepository(_context);

        public async Task<string> save()
        {
            string result = "";
            try
            {
                var recordsAffrected = await _context.SaveChangesAsync();
                result = recordsAffrected > 0?"true":"false";

            }
            catch (Exception ee)
            {
                result = ee.Message;
            }
            return result;
        }
    }
}
