using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendyT.DTO
{
    public class ReviewDTO
    {
        public int Rating { get; set; }
        public string Comment { get; set; }

        //ForeignKeys
        public long ReviewerId { get; set; }
        public long ProductId { get; set; }

        //Navigationd Props
        public virtual UserDTO Reviewer { get; set; }
        public virtual ProductDTO Product { get; set; }

    }
}
