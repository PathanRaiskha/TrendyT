using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TrendyT.DTO
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Role {  get; set; }
        public bool Gender { get; set; }
        public string MobileNumber { get; set; }


        public long AddressId { get; set; }

        //Navigation Props
        public virtual AddressDTO? Address { get; set; }
        public virtual ICollection<OrderDTO>? Orders { get; set; }
        public virtual ICollection<ReviewDTO>? Reviews { get; set; }

    }
}
