using AspAZ.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspAZ.DataAccess.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x=>x.ProductCode).IsRequired().HasMaxLength(6);
            builder.Property(x=>x.BarCode).IsRequired().HasMaxLength(13);

            builder.HasIndex(x => x.ProductCode).IsUnique();
            builder.HasIndex(x => x.BarCode).IsUnique();

            builder.Property(x => x.Description).HasMaxLength(220);

            builder.HasMany(x => x.ProductProperties)
                   .WithOne(x => x.Product)
                   .HasForeignKey(x => x.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.ProductCarts)
                   .WithOne(x => x.Product)
                   .HasForeignKey(x => x.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
