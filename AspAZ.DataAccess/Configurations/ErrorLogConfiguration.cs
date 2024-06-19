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
    internal class ErrorLogConfiguration : IEntityTypeConfiguration<ErrorLog>
    {
        public void Configure(EntityTypeBuilder<ErrorLog> builder)
        {
            builder.HasKey(x => x.ErrorId);
            builder.Property(x => x.ErrorId).HasDefaultValue(Guid.NewGuid());

        }
    }
}
