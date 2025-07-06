using HRManagement.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagement.Data.Configurations;

public class SalaryBonusConfiguration : IEntityTypeConfiguration<SalaryBonus>
{
    public void Configure(EntityTypeBuilder<SalaryBonus> builder)
    {
        builder.ToTable("SalaryBonuses");
        builder.HasKey(sb => sb.SalaryBonusID);
        builder.Property(sb => sb.SalaryBonusID)
            .ValueGeneratedOnAdd();

       
        builder.Property(sb => sb.BonusType)
            .HasMaxLength(50);

        builder.Property(sb => sb.Amount)
            .HasColumnType("decimal(18,2)");

        builder.Property(sb => sb.Description)
            .IsRequired()
            .HasMaxLength(500);

        
        builder.HasOne(sb => sb.User)
            .WithMany()
            .HasForeignKey(sb => sb.UserID)
            .OnDelete(DeleteBehavior.Cascade);
    }
} 