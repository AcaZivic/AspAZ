using AspAZ.DataAccess;
using AspAZ.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspAZ.DataAccess.Configurations
{
    public class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
           
            builder.Property(x => x.Description).HasMaxLength(120);

            builder.HasMany(x=>x.Products)
                   .WithOne(x=>x.Manufacturer)
                   .HasForeignKey(x=>x.ManufacturerId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
