using HRManagement.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagement.Data.Configurations;

public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
{
    public void Configure(EntityTypeBuilder<Attendance> builder)
    {
        builder.ToTable("Attendances");
        builder.HasKey(a => a.AttendanceID);
        builder.Property(a => a.AttendanceID)
            .ValueGeneratedOnAdd()
            .IsRequired();
        builder.Property(a => a.UserID)
            .IsRequired();
        builder.Property(a => a.CheckInTime)
            .IsRequired(false);
        builder.Property(a => a.CheckOutTime)
            .IsRequired(false);
        builder.Property(a => a.Location)
            .IsRequired(false)
            .HasMaxLength(200);
        builder.Property(a => a.WorkHours)
            .IsRequired(false)
            .HasPrecision(18, 2);
        builder.Property(a => a.OvertimeHours)
            .IsRequired()
            .HasPrecision(18, 2);
        builder.Property(a => a.AttendanceDate)
            .IsRequired()
            .HasColumnType("date");
        builder.Property(a => a.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()")
            .ValueGeneratedOnAdd();
        builder.Property(a => a.UpdatedAt)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()")
            .ValueGeneratedOnAddOrUpdate();
        builder.HasOne(a => a.User)
            .WithMany(u => u.Attendances)
            .HasForeignKey(a => a.UserID)
            .OnDelete(DeleteBehavior.Cascade);
    }
}