using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrendyT.Data.Entities;

namespace TrendyT.Data.EntityConfigrations
{
    public class AddressConfigration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.HasMany<ApplicationUser>(x=>x.User)
                .WithOne(x => x.Address)
                .HasForeignKey(x => x.AddressId)
                .OnDelete(DeleteBehavior.NoAction); ;

            builder.HasMany<Order>(x=>x.Order)
                .WithOne(x=>x.ShipingAddress)
                .HasForeignKey(x=>x.ShipingAddressId)
                .OnDelete(DeleteBehavior.NoAction); ;

        }
    }
}
