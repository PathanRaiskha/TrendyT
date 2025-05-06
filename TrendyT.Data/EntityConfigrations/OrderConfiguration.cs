using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrendyT.Data.Entities;

namespace TrendyT.Data.EntityConfigrations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
           
        
            
        
                builder.HasKey(x => new { x.Id  });

                builder.HasOne<ApplicationUser>(x => x.OrderedUser)
                    .WithMany(x => x.Orders )
                    .HasForeignKey(x => x.OrderedUserId);

               


            
        }

    }
}

