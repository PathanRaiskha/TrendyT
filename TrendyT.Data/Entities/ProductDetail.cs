using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyT.Common.Enums;

namespace TrendyT.Data.Entities
{
    public class ProductDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public bool IsFullSleeve { get; set; }
        public ProductColor Color { get; set; }
        public Material Material { get; set; }
        public NeckType NeckType { get; set; }
        public ProductSize Size { get; set; }

        public long ProductId { get; set; }
        public virtual Product Product { get; set; } 
    }
}
