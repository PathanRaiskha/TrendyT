using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public  class OrderRepository:IorderRepo

    {
        private readonly ApplicationDbContext _context;
       

        //public OrderRepository(ApplicationDbContext context)
        //{
        //    this.context = context;
        //}

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
            
        }
        public async Task<List<Order>> GetAllOrder()
        {
            var res = await _context.Orders.ToListAsync();
            //res.ForEach(res => res.Address.User = null);

            return res.ToList();
        }

        //    public async Task<PagedReesult<List<OrderDTO>>> GetUsersPagedAsync(int pageIndex = 0, int pageSize = 10, string orderBy = "", bool orderByAsc = true, string searchTerm = "")
        //    {
        //        PagedReesult<List<OrderDTO>> pagedReesult = null;
        //        int totalRecords = 0;
        //        List<OrderDTO> ll = null;
        //        Func<OrderDTO, string> orderByFunc = null;

        //        switch (orderBy)
        //        {
        //            case "Email": orderByFunc = x => x.Status; break;
        //            //case "mobile": orderByFunc = x => x.Password; break;
        //            default: orderByFunc = x => (x.Status); break;
        //        }

        //        if (searchTerm == "")
        //        {

        //            //ll = await _context.Users.Include(x => x.Address).ToListAsync();
        //            //var rr = from user in _context.Orders.Include(x => x.Address)
        //                     //join userRole in _context.UserRoles on user.Id equals userRole.UserId
        //                     //join role in _context.Roles on userRole.RoleId equals role.Id
        //                     select new OrderDTO
        //                     {
        //                         Id = Order.Id,
        //                         FirstName = user.FirstName,
        //                         LastName = user.LastName,
        //                         Email = user.Email,
        //                         Password = user.PasswordHash,
        //                         Role = role.Name,
        //                         Gender = user.Gender,
        //                         MobileNumber = user.MobileNumber,
        //                         AddressId = user.AddressId,
        //                         Address = _mapper.Map<AddressDTO>(user.Address)

        //                     };
        //            ll = rr.ToList();


        //        }
        //        else
        //        {
        //            //ll = await _context.Users.Include(x => x.Address).Where(x=> (x.FirstName + " " + x.LastName).Contains(searchTerm)
        //            //                                                            || x.Email.Contains(searchTerm) || x.MobileNumber.Contains(searchTerm)
        //            //                                                            || x.Address.Street.Contains(searchTerm) || x.Address.City.Contains(searchTerm) || x.Address.District.Contains(searchTerm)
        //            //                                                            || x.Address.State.Contains(searchTerm) || x.Address.PostalCode.Contains(searchTerm)).ToListAsync();
        //            var rr = from Order in _context.Orders.Include(x => x.OrderedUser)
        //                     join userRole in _context.UserRoles on user.Id equals userRole.UserId
        //                     join role in _context.Roles on userRole.RoleId equals role.Id
        //                     where (user.FirstName + " " + user.LastName).Contains(searchTerm)
        //                     || user.Email.Contains(searchTerm)
        //                     || user.MobileNumber.Contains(searchTerm)
        //                     || user.Address.Street.Contains(searchTerm) || user.Address.City.Contains(searchTerm) || user.Address.District.Contains(searchTerm)
        //                     || user.Address.State.Contains(searchTerm) || user.Address.PostalCode.Contains(searchTerm)
        //                     select new UserDTO
        //                     {
        //                         Id = user.Id,
        //                         FirstName = user.FirstName,
        //                         LastName = user.LastName,
        //                         Email = user.Email,
        //                         Password = user.PasswordHash,
        //                         Role = role.Name,
        //                         Gender = user.Gender,
        //                         MobileNumber = user.MobileNumber,
        //                         AddressId = user.AddressId,
        //                         Address = _mapper.Map<AddressDTO>(user.Address)

        //                     };

        //        }
        //        ll = orderByAsc ? ll.OrderBy(orderByFunc).ToList() : ll.OrderByDescending(orderByFunc).ToList();
        //        totalRecords = ll.Count;
        //        ll = ll.Skip((pageIndex * 1) * pageSize).Take(pageSize).ToList();
        //        //ll.ForEach(res => res.Address.User = null);

        //        pagedReesult = new PagedReesult<List<UserDTO>>(ll, totalRecords);
        //        return pagedReesult;
        //    }
        //}
    }
}
