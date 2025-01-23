using ExamCake.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamCake.DAL.Configurations
{
    public class ChiefConfiguration : IEntityTypeConfiguration<Chief>
    {
        public void Configure(EntityTypeBuilder<Chief> builder)
        {
            builder.Property(p => p.DesignationId).IsRequired();
            builder.Property(p => p.FullName).IsRequired();
        }
    }
}
