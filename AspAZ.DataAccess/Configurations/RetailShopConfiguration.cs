using AspAZ.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspAZ.DataAccess.Configurations
{
    internal class RetailShopConfiguration : IEntityTypeConfiguration<RetailShop>
    {
        public void Configure(EntityTypeBuilder<RetailShop> builder)
        {
            builder.Property(x => x.Address).IsRequired().HasMaxLength(100);
            builder.Property(x => x.AddressNum).HasMaxLength(5);
            builder.Property(x => x.City).HasMaxLength(50);
            builder.Property(x=>x.Telephone).HasMaxLength(15);

            builder.HasMany(x=>x.Carts)
                   .WithOne(x=>x.RetailShop)
                   .HasForeignKey(x=>x.RetailShopId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
