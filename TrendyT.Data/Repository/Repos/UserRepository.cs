using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyT.Data.Entities;
using TrendyT.Data.Repository.RepoInterfaces;
using TrendyT.DTO;

namespace TrendyT.Data.Repository.Repos
{
    public class UserRepository : IUserRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(ApplicationDbContext context, IMapper mapper) {
           _context = context;
            _mapper = mapper;
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

        public async Task<PagedReesult<List<UserDTO>>> GetUsersPagedAsync(int pageIndex = 0, int pageSize = 10, string orderBy = "", bool orderByAsc = true, string searchTerm = "")
        {
            PagedReesult<List<UserDTO>> pagedReesult=null ;
            int totalRecords = 0;
            List<UserDTO> ll = null;
            Func<UserDTO, string> orderByFunc = null;

            switch (orderBy)
            {
                case "Email":orderByFunc = x =>x.Email;break;
                //case "mobile": orderByFunc = x => x.Password; break;
                default: orderByFunc = x => (x.FirstName + " " +x.LastName); break;
            }

            if (searchTerm == "")
            {

                //ll = await _context.Users.Include(x => x.Address).ToListAsync();
                var rr=from user in _context.Users.Include(x => x.Address)
                join userRole in _context.UserRoles on user.Id equals userRole.UserId
                join role in _context.Roles on userRole.RoleId equals role.Id
                select new UserDTO
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password=user.PasswordHash,
                    Role = role.Name,
                    Gender = user.Gender,
                    MobileNumber = user.MobileNumber,
                    AddressId = user.AddressId,
                    Address = _mapper.Map<AddressDTO>(user.Address)  

                };
                ll = rr.ToList();


            }
            else
            {
                //ll = await _context.Users.Include(x => x.Address).Where(x=> (x.FirstName + " " + x.LastName).Contains(searchTerm)
                //                                                            || x.Email.Contains(searchTerm) || x.MobileNumber.Contains(searchTerm)
                //                                                            || x.Address.Street.Contains(searchTerm) || x.Address.City.Contains(searchTerm) || x.Address.District.Contains(searchTerm)
                //                                                            || x.Address.State.Contains(searchTerm) || x.Address.PostalCode.Contains(searchTerm)).ToListAsync();
                var rr = from user in _context.Users.Include(x => x.Address)
                         join userRole in _context.UserRoles on user.Id equals userRole.UserId
                         join role in _context.Roles on userRole.RoleId equals role.Id
                         where (user.FirstName + " " + user.LastName).Contains(searchTerm)
                         || user.Email.Contains(searchTerm) 
                         || user.MobileNumber.Contains(searchTerm)
                         || user.Address.Street.Contains(searchTerm) || user.Address.City.Contains(searchTerm) || user.Address.District.Contains(searchTerm)
                         || user.Address.State.Contains(searchTerm) || user.Address.PostalCode.Contains(searchTerm)
                         select new UserDTO
                         {
                             Id = user.Id,
                             FirstName = user.FirstName,
                             LastName = user.LastName,
                             Email = user.Email,
                             Password = user.PasswordHash,
                             Role = role.Name,
                             Gender = user.Gender,
                             MobileNumber = user.MobileNumber,
                             AddressId= user.AddressId, 
                             Address = _mapper.Map<AddressDTO>(user.Address)

                         };

            }
            ll = orderByAsc ? ll.OrderBy(orderByFunc).ToList() : ll.OrderByDescending(orderByFunc).ToList();
            totalRecords=ll.Count;
            ll = ll.Skip((pageIndex * 1) * pageSize).Take(pageSize).ToList();
            //ll.ForEach(res => res.Address.User = null);

            pagedReesult = new PagedReesult<List<UserDTO>>(ll,totalRecords);
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

            try
            {
                var user1 = await _context.Users.FindAsync(user.Id);
                
                if (user1 == null)
                {
                    return false;
                }
               

                user1.FirstName= user.FirstName;    
                user1.LastName= user.LastName;  
                user1.Email= user.Email;    
                user1.Gender= user.Gender;  
                user1.MobileNumber= user.MobileNumber;
                user1.AddressId= user.AddressId;


                user1.Address = user.Address; 


                _context.Users.Update(user1);
                
                //var result = await _context.SaveChangesAsync();
                //return result > 0;
            }
            catch (Exception ee)
            {
                return false ;
            }

             return true;
        }
    }
}
