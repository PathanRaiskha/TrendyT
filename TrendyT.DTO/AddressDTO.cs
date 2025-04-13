using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendyT.DTO
{
    public class AddressDTO
    {
        public long Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }

        //Navigation Props
        public virtual ICollection<UserDTO>? User { get; set; }
        public virtual ICollection<OrderDTO>? Order { get; set; }
    }
}
