using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendyT.Data.Entities
{
    public class Review
    {
        public int Rating { get; set; }
        public string Comment { get; set; }

        //ForeignKeys
        public string ReviewerId { get; set; }
        public long ProductId { get; set; }

        //Navigationd Props
        public virtual ApplicationUser Reviewer { get; set; }
        public virtual Product Product { get; set; }


    }
}
