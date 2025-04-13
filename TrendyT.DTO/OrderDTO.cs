using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TrendyT.DTO
{
    public class OrderDTO
    {
        public long Id { get; set; }
        public string Status { get; set; }
        public double TotalBill { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime OrderStatusChangedDate { get; set; }



        public long ShipingAddressId { get; set; }
        public long OrderedUserId { get; set; }

        //Mapping 
        public virtual AddressDTO ShipingAddress { get; set; }
        public virtual UserDTO OrderedUser { get; }

    }
}
