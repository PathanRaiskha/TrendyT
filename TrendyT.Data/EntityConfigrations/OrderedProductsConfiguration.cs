using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyT.Data.Entities;

namespace TrendyT.Data.EntityConfigrations
{
    public class OrderedProductsConfiguration : IEntityTypeConfiguration<OrderedProducts>
    {
        public void Configure(EntityTypeBuilder<OrderedProducts> builder)
        {
            builder.HasKey(x=> new {x.OrderId, x.ProductId});

            builder.HasOne<Order>(x => x.Order)
                .WithMany(x => x.ProductList)
                .HasForeignKey(x => x.OrderId);

            builder.HasOne<Product>(x => x.Product)
                .WithMany(x=>x.OrdersList)
                .HasForeignKey(x => x.ProductId);


        }
    }
}
