using HRManagement.Data.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.Data.Data.Configurations
{
    public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
    {

        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.ToTable("Attendances");
            builder.HasKey(a => a.AttendanceID);
            builder.Property(a => a.CheckInTime).IsRequired();
            builder.Property(a => a.CheckOutTime).IsRequired();
            builder.Property(a => a.CheckInMethod).IsRequired().HasMaxLength(20);
            builder.Property(a => a.Location).IsRequired().HasMaxLength(50);
            builder.Property(a => a.WorkHours).IsRequired().HasColumnType("decimal(5,2)");
            builder.Property(a => a.OvertimeHours).IsRequired().HasColumnType("decimal(5,2)");
            builder.Property(a => a.AttendanceDate).IsRequired();
            builder.Property(a => a.CreatedAt).IsRequired();
            builder.Property(a => a.UpdatedAt).IsRequired();

            builder.HasOne(a => a.Employee)
                .WithMany(e => e.Attendances)
                .HasForeignKey(a => a.EmployeeID)
                .OnDelete(DeleteBehavior.Cascade);

           
        }

    }
}
