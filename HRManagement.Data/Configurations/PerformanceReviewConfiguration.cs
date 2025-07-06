using HRManagement.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagement.Data.Configurations;

public class PerformanceReviewConfiguration : IEntityTypeConfiguration<PerformanceReview>
{
    public void Configure(EntityTypeBuilder<PerformanceReview> builder)
    {
        builder.ToTable("PerformanceReviews");
        builder.HasKey(pr => pr.PerformanceReviewID);
        builder.Property(pr => pr.PerformanceReviewID)
            .ValueGeneratedOnAdd();

        builder.Property(pr => pr.UserID)
            .IsRequired();


        builder.Property(pr => pr.Rating)
            .HasColumnType("decimal(3,1)");

        builder.Property(pr => pr.Comments)
            .HasMaxLength(1000);

        builder.Property(pr => pr.Status)
            .HasMaxLength(20);

       

        builder.HasOne(pr => pr.User)
            .WithMany()
            .HasForeignKey(pr => pr.UserID)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(pr => pr.Reviewer)
            .WithMany()
            .HasForeignKey(pr => pr.ReviewerID)
            .OnDelete(DeleteBehavior.Restrict);
    }
} 