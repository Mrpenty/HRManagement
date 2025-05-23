using HRManagement.Data.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.Data.Data.Configurations
{
    public class LeaveRequestConfiguration : IEntityTypeConfiguration<LeaveRequest>
    {
        public void Configure(EntityTypeBuilder<LeaveRequest> builder)
        {
            builder.ToTable("LeaveRequests");
            builder.HasKey(lr => lr.LeaveRequestID);
            builder.Property(lr => lr.LeaveType).IsRequired().HasMaxLength(20);
            builder.Property(lr => lr.StartDate).IsRequired();
            builder.Property(lr => lr.EndDate).IsRequired();
            builder.Property(lr => lr.Reason).IsRequired().HasMaxLength(255);
            builder.Property(lr => lr.Status).IsRequired().HasMaxLength(20);
            builder.Property(lr => lr.CreatedAt).IsRequired();
            builder.Property(lr => lr.UpdatedAt).IsRequired();

            builder.HasOne(lr => lr.Employee)
                .WithMany(e => e.LeaveRequests)
                .HasForeignKey(lr => lr.EmployeeID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(lr => lr.Approver)
                .WithMany(e => e.ApprovedLeaveRequests)
                .HasForeignKey(lr => lr.ApproverID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
