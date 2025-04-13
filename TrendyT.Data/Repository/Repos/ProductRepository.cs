using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyT.Data.Entities;
using TrendyT.Data.Repository.RepoInterfaces;

namespace TrendyT.Data.Repository.Repos
{
    public class ProductRepository : IProductRepo
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddProduct(Product product)
        {
            bool success =false;
            try
            {
                var rr=await _context.Products.AddAsync(product);    
                success = true;
            }
            catch (Exception ee)
            {

            }
            return success;
        }
        public async Task<List<Product>> GetAllProducts()
        {
            var res = await _context.Products.Include(x=>x.ProductDetail).ToListAsync ();
            res.ForEach(x => { x.ProductDetail.Product = null; });

            return res.ToList();
        }

        public async Task<PagedReesult<List<Product>>> GetProductsPagedAsync(int pageIndex = 0, int pageSize = 10, string orderBy = "", bool orderByAsc = true, string searchTerm = "")
        {
            PagedReesult<List<Product>> pagedReesult = new PagedReesult<List<Product>>(null, 0);
            int totalRecords = 0;
            List<Product> ll = null;
            Func<Product, double> orderByFunc = null;
            Func<Product, string> orderByFunc1 = null;

            switch (orderBy)
            {
                case "Price": orderByFunc = x => (x.Price); break;
                case "Quantity": orderByFunc = x => (x.Quantity); break;
                default: orderByFunc1 = x => x.Name; break;
            }

            if (searchTerm == "")
            {
                ll = await _context.Products.Include(x => x.ProductDetail).ToListAsync();
            }
            else
            {
                ll = await _context.Products.Include(x => x.ProductDetail).Where(x => (x.Name ).Contains(searchTerm) ).ToListAsync();
            }
            if (orderBy == "Price" || orderBy == "Quantity")
            {
                ll = orderByAsc ? ll.OrderBy(orderByFunc).ToList() : ll.OrderByDescending(orderByFunc).ToList();

            }
            else
            {
                ll = orderByAsc ? ll.OrderBy(orderByFunc1).ToList() : ll.OrderByDescending(orderByFunc1).ToList();
            }
                totalRecords = ll.Count;
                ll = ll.Skip((pageIndex * 1) * pageSize).Take(pageSize).ToList();
                ll.ForEach(res => res.ProductDetail.Product = null);

                pagedReesult = new PagedReesult<List<Product>>(ll, totalRecords);
            
            return pagedReesult;
        }
        public async Task<bool> DeleteProduct(string productId)
        {
            var Product = await _context.Products.FirstOrDefaultAsync(x => x.Id == Convert.ToInt64(productId));
            _context.Products.Remove(Product);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
        public async Task<bool> UpdateProduct(Product product)
        {

            _context.Products.Update(product);
            return true;
        }

    }
}
