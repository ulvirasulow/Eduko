using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.Property(t => t.Fullname)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.Email)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(t => t.Phone)
            .IsRequired(false)
            .HasMaxLength(20);

        builder.Property(t => t.Position)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.ProfileImgUrl)
            .IsRequired(false)
            .HasMaxLength(1000);

        builder.Property(t => t.PersonalExperience)
            .IsRequired(false)
            .HasMaxLength(2000);

        builder.Property(t => t.Address)
            .IsRequired(false)
            .HasMaxLength(500);

        builder.Property(t => t.CertificatesUrl)
            .IsRequired(false)
            .HasMaxLength(1000);

        builder.Property(t => t.Education)
            .IsRequired(false)
            .HasMaxLength(1000);

        builder.Property(t => t.Achievements)
            .IsRequired(false)
            .HasMaxLength(2000);

        builder.Property(t => t.Skills)
            .IsRequired(false)
            .HasMaxLength(1000);

        builder.Property(t => t.FacebookUrl)
            .IsRequired(false)
            .HasMaxLength(1000);

        builder.Property(t => t.TwitterUrl)
            .IsRequired(false)
            .HasMaxLength(1000);

        builder.Property(t => t.LinkedInUrl)
            .IsRequired(false)
            .HasMaxLength(1000);

        builder.Property(t => t.InstagramUrl)
            .IsRequired(false)
            .HasMaxLength(1000);

        builder.HasMany(t => t.Blogs)
            .WithOne(b => b.Teacher)
            .HasForeignKey(b => b.TeacherId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(t => t.Courses)
            .WithOne(c => c.Teacher)
            .HasForeignKey(c => c.TeacherId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}