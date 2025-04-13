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
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(x => new { x.ReviewerId, x.ProductId });

            builder.HasOne(x => x.Reviewer)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.ReviewerId);

            builder.HasOne(x=>x.Product)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.ProductId);
        }
    }
}
