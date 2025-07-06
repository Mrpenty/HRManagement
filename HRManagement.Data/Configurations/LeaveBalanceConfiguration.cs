using HRManagement.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagement.Data.Configurations;

public class LeaveBalanceConfiguration : IEntityTypeConfiguration<LeaveBalance>
{
    public void Configure(EntityTypeBuilder<LeaveBalance> builder)
    {
        builder.ToTable("LeaveBalances");
        builder.HasKey(lb => lb.LeaveBalanceID);
        builder.Property(lb => lb.LeaveBalanceID)
            .ValueGeneratedOnAdd();

        builder.Property(lb => lb.UserID)
            .IsRequired();

      
        builder.Property(lb => lb.LeaveType)
            .HasMaxLength(50);

        builder.Property(lb => lb.TotalDays)
            .HasColumnType("decimal(5,1)")
            .IsRequired();

        builder.Property(lb => lb.UsedDays)
            .HasColumnType("decimal(5,1)");

        builder.Property(lb => lb.RemainingDays)
            .HasColumnType("decimal(5,1)");

        builder.Property(lb => lb.PendingDays)
            .HasColumnType("decimal(5,1)");

        builder.Property(lb => lb.Notes)
            .HasMaxLength(500);

        builder.HasOne(lb => lb.User)
            .WithMany()
            .HasForeignKey(lb => lb.UserID)
            .OnDelete(DeleteBehavior.Cascade);



        // Composite unique constraint for UserID, Year, and LeaveType
        builder.HasIndex(lb => new { lb.UserID, lb.Year, lb.LeaveType })
            .IsUnique();
    }
} 