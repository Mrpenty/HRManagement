using HRManagement.Data.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Data.Data.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments");
            builder.HasKey(d => d.DepartmentID);
            builder.Property(d => d.DepartmentName).IsRequired().HasMaxLength(100);
            builder.Property(d => d.CreatedAt).IsRequired();
            builder.Property(d => d.UpdatedAt).IsRequired();
        }
    }
}
