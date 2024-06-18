using AspAZ.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AspAZ.DataAccess.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<GroupEmp>
    {
        public void Configure(EntityTypeBuilder<GroupEmp> builder)
        {
            builder.HasMany(x => x.Employees)
                   .WithOne(x => x.GroupEmp)
                   .HasForeignKey(x => x.GroupEmpId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
