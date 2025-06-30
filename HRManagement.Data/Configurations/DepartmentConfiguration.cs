using HRManagement.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagement.Data.Configurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("Departments");
        builder.HasKey(d => d.DepartmentID);
        builder.Property(d => d.DepartmentID)
            .ValueGeneratedOnAdd()
            .IsRequired();
        builder.Property(d => d.DepartmentName)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(d => d.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()")
            .ValueGeneratedOnAdd();
        builder.Property(d => d.Status)
            .IsRequired()
            .HasMaxLength(20)
            .HasDefaultValue("Inactive");
        builder.Property(d => d.UpdatedAt)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()")
            .ValueGeneratedOnAddOrUpdate();
        builder.HasMany(d => d.Users)
            .WithOne(u => u.Department)
            .HasForeignKey(u => u.DepartmentID)
            .OnDelete(DeleteBehavior.SetNull);
    }
}