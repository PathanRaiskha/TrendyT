using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendyT.Data.Entities
{
    public class AddToCart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCustomizable { get; set; }

        //Navigation Prop
        public virtual ProductDetail ProductDetail { get; set; }
        public virtual ICollection<OrderedProducts> OrdersList { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }


    }
}
