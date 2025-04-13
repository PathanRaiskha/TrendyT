using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendyT.DTO
{
    public class ProductImageDTO
    {
        public IFormFile FrontImage { get; set; }
        public IFormFile BackImage { get; set; }
        public IFormFile LeftImage { get; set; }
        public IFormFile RightImage { get; set; }
        public long ProductId { get; set; }
    }
}
