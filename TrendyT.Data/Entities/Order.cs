using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendyT.Data.Entities
{
    public class Order
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Status { get; set; }
        public double TotalBill { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime OrderStatusChangedDate { get; set; }


        //ForeignKeys
        public long ShipingAddressId { get; set; }
        public string OrderedUserId { get; set; }

        //Navigationd Props
        public virtual Address ShipingAddress { get; set; }
        public virtual ApplicationUser OrderedUser { get;}
        public virtual ICollection<OrderedProducts> ProductList { get; set; }

    }
}
