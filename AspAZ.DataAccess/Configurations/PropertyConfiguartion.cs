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
    internal class PropertyConfiguartion : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
       
            builder.Property(x => x.MeasureUnit).IsRequired().HasMaxLength(30);

            builder.HasMany(x=>x.PropertyCategories)
                   .WithOne(x=>x.Property)
                   .HasForeignKey(x=>x.PropertyId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
