using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendyT.DTO
{
    public class ProductDTO
    {
        public long Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCustomizable { get; set; }

        //Navigation Prop
        public virtual ProductDetailDTO ProductDetail { get; set; }
        public virtual ICollection<OrderedProductsDTO>? OrdersList { get; set; }
        public virtual ICollection<ReviewDTO>? Reviews { get; set; }
    }
}
