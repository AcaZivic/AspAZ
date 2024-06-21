using AspAZ.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspAZ.DataAccess.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.Property(x=>x.Description).HasMaxLength(120);
            

            builder.HasMany(x=>x.Children)
                   .WithOne(x=>x.Parent)
                   .HasForeignKey(x=>x.ParentId)
                   .OnDelete(DeleteBehavior.Restrict);


            builder.HasMany(x => x.PropertyCategories)
                   .WithOne(x => x.Category)
                   .HasForeignKey(x => x.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x=>x.Products)
                   .WithOne(x=>x.Category)
                   .HasForeignKey(x=>x.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
