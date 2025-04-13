using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyT.Data.Entities;
using TrendyT.Data.Repository.RepoInterfaces;

namespace TrendyT.Data.Repository.Repos
{
    public class UserRepository : IUserRepo
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) {
           _context = context;
        }

        public async Task<bool> AddUser(ApplicationUser user)
        {
            var result =await _context.Users.AddAsync(user);
            return true;
        }

        public async Task<ApplicationUser> GetUser(string EmailId, string Password)
        {
            ApplicationUser result = null;//  _context.Users.Include(x=>x.Address).FirstOrDefault(x=>x.Email==EmailId && x.Password==Password);
            if (result != null)
            {
                result.Address.User = null;

            }
            return result;
        }
        public async Task<List<ApplicationUser>> GetAllUsers()
        {
            var res=await _context.Users.Include(x => x.Address).ToListAsync();
            res.ForEach(res=> res.Address.User = null);

            return res.ToList();
        }

        public async Task<PagedReesult<List<ApplicationUser>>> GetUsersPagedAsync(int pageIndex = 0, int pageSize = 10, string orderBy = "", bool orderByAsc = true, string searchTerm = "")
        {
            PagedReesult<List<ApplicationUser>> pagedReesult = new PagedReesult<List<ApplicationUser>>(null,0);
            int totalRecords = 0;
            List<ApplicationUser> ll = null;
            Func<ApplicationUser, string> orderByFunc = null;

            switch (orderBy)
            {
                case "Email":orderByFunc = x =>x.Email;break;
                //case "mobile": orderByFunc = x => x.Password; break;
                default: orderByFunc = x => (x.FirstName + " " +x.LastName); break;
            }

            if (searchTerm == "")
            {
                 ll = await _context.Users.Include(x => x.Address).ToListAsync();
            }
            else
            {
                ll = await _context.Users.Include(x => x.Address).Where(x=> (x.FirstName + " " + x.LastName).Contains(searchTerm)
                                                                            || x.Email.Contains(searchTerm) || x.MobileNumber.Contains(searchTerm)
                                                                            || x.Address.Street.Contains(searchTerm) || x.Address.City.Contains(searchTerm) || x.Address.District.Contains(searchTerm)
                                                                            || x.Address.State.Contains(searchTerm) || x.Address.PostalCode.Contains(searchTerm)).ToListAsync();
            }
            ll = orderByAsc ? ll.OrderBy(orderByFunc).ToList() : ll.OrderByDescending(orderByFunc).ToList();
            totalRecords=ll.Count;
            ll = ll.Skip((pageIndex * 1) * pageSize).Take(pageSize).ToList();
            ll.ForEach(res => res.Address.User = null);

            pagedReesult = new PagedReesult<List<ApplicationUser>>(ll,totalRecords);
            return pagedReesult;
        }

        public async Task<bool> DeleteUser(string userId)
        {
            var User= await _context.Users.FirstOrDefaultAsync(x=>x.Id.ToString()==userId);
            _context.Users.Remove(User);
            var result = await _context.SaveChangesAsync();
            return result>0;
        }
        public async Task<bool> UpdateUser(ApplicationUser user)
        {
            
             _context.Users.Update(user);
            return true;
        }
    }
}
