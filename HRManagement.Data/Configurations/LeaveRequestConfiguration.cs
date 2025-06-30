using HRManagement.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagement.Data.Configurations;

public class LeaveRequestConfiguration : IEntityTypeConfiguration<LeaveRequest>
{
    public void Configure(EntityTypeBuilder<LeaveRequest> builder)
    {
        builder.ToTable("LeaveRequests");
        builder.HasKey(lr => lr.LeaveRequestID);
        builder.Property(lr => lr.LeaveRequestID)
            .ValueGeneratedOnAdd()
            .IsRequired();
        builder.Property(lr => lr.UserID)
            .IsRequired();
        builder.Property(lr => lr.StartDate)
            .IsRequired()
            .HasColumnType("date");
        builder.Property(lr => lr.EndDate)
            .IsRequired()
            .HasColumnType("date");
        builder.Property(lr => lr.LeaveType)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(lr => lr.Reason)
            .IsRequired()
            .HasMaxLength(500);
        builder.Property(lr => lr.ApproverNote)
            .HasMaxLength(500);
        builder.Property(lr => lr.Status)
            .HasDefaultValue("Pending")
            .IsRequired()
            .HasMaxLength(20);
        builder.Property(lr => lr.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()")
            .ValueGeneratedOnAdd();
        builder.Property(lr => lr.UpdatedAt)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()")
            .ValueGeneratedOnAddOrUpdate();
        builder.HasOne(lr => lr.User)
            .WithMany(u => u.LeaveRequests)
            .HasForeignKey(lr => lr.UserID)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(lr => lr.Approver)
            .WithMany(u => u.ApprovedLeaveRequests)
            .HasForeignKey(lr => lr.ApproverID)
            .OnDelete(DeleteBehavior.Restrict);
    }
}