using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.Property(s => s.Fullname)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(s => s.Email)
            .IsRequired()
            .HasMaxLength(256);

        builder.HasMany(s => s.Comments)
            .WithOne(c => c.Student)
            .HasForeignKey(c => c.StudentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}