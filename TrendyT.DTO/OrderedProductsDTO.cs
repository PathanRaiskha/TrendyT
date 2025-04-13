using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendyT.DTO
{
    public class OrderedProductsDTO
    {
        public int ProductQuantity { get; set; }

        //ForeignKeys
        public long OrderId { get; set; }
        public long ProductId { get; set; }

        //Navigationd Props
        public OrderDTO Order { get; set; }
        public ProductDTO Product { get; set; }
    }
}
