using HRManagement.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagement.Data.Configurations;

public class ContractTypeConfiguration : IEntityTypeConfiguration<ContractType>
{
    public void Configure(EntityTypeBuilder<ContractType> builder)
    {
        builder.ToTable("ContractTypes");
        builder.HasKey(ct => ct.ContractTypeID);
        builder.Property(ct => ct.ContractTypeID)
            .ValueGeneratedOnAdd();
 
        builder.HasMany(ct => ct.Users)
            .WithOne(u => u.ContractType)
            .HasForeignKey(u => u.ContractTypeID)
            .OnDelete(DeleteBehavior.SetNull);
    }
}