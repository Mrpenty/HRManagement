using HRManagement.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagement.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.FirstName)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(u => u.LastName)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(u => u.DateOfBirth)
            .IsRequired(false);
        builder.Property(u => u.HireDate)
            .IsRequired(false);
        builder.Property(e => e.CreatedAt)
            .IsRequired(true)
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAdd();
        builder.Property(e => e.UpdatedAt)
            .IsRequired(true)
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAddOrUpdate();
        builder.Property(u => u.RefreshToken)
            .IsRequired(false)
            .HasMaxLength(500);
        builder.Property(u => u.RefreshTokenExpiryTime)
            .IsRequired(false);
        builder.Property(u => u.ProfilePicture) 
            .IsRequired(false)
            .HasMaxLength(500);
        builder.HasOne(u => u.Department)
            .WithMany(d => d.Users)
            .HasForeignKey(u => u.DepartmentID)
            .OnDelete(DeleteBehavior.SetNull);
        builder.HasOne(u => u.EmployeeLevel)
            .WithMany(el => el.Users)
            .HasForeignKey(u => u.EmployeeLevelID)
            .OnDelete(DeleteBehavior.SetNull);
        builder.HasOne(u => u.ContractType)
            .WithMany(ct => ct.Users)
            .HasForeignKey(u => u.ContractTypeID)
            .OnDelete(DeleteBehavior.SetNull);
        builder.HasOne(u => u.Position)
            .WithMany(p => p.Users)
            .HasForeignKey(u => u.PositionID)
            .OnDelete(DeleteBehavior.SetNull);
        builder.HasMany(u => u.Salaries)
            .WithOne(s => s.User)
            .HasForeignKey(s => s.UserID)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(u => u.Payslips)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserID)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(u => u.Attendances)
            .WithOne(a => a.User)
            .HasForeignKey(a => a.UserID)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(u => u.LeaveRequests)
            .WithOne(lr => lr.User)
            .HasForeignKey(lr => lr.UserID)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(u => u.Manager)
            .WithMany()
            .HasForeignKey(u => u.ManagedByUserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(u => u.ApprovedLeaveRequests)
            .WithOne(lr => lr.Approver)
            .HasForeignKey(lr => lr.ApproverID)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.PerformanceReviews)
            .WithOne(pr => pr.User)
            .HasForeignKey(pr => pr.UserID)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.ReviewedPerformanceReviews)
            .WithOne(pr => pr.Reviewer)
            .HasForeignKey(pr => pr.ReviewerID)
            .OnDelete(DeleteBehavior.Restrict);
    }
}