
using TrendyT.Common.Enums;
using Microsoft.AspNetCore.Http;


namespace TrendyT.DTO
{
    public class ProductDetailDTO
    {
        public long Id { get; set; }
        public bool IsFullSleeve { get; set; }
        public ProductColor Color { get; set; }
        public Material Material { get; set; }
        public NeckType NeckType { get; set; }
        public ProductSize Size { get; set; }
       
        public string? FrontImage { get; set; }
        public string? BackImage { get; set; }
        public string? LeftImage { get; set; }
        public string? RightImage { get; set; }

        public long ProductId { get; set; }
    }
}
