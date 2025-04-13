using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendyT.Data.Entities
{
    public class OrderedProducts
    {
        
        public int ProductQuantity { get; set; }

        //ForeignKeys
        public long OrderId { get; set; }
        public long ProductId { get; set; }

        //Navigationd Props
        public Order Order { get; set; }
        public Product Product { get; set; }

    }
}
