using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.StudentId);

            builder.Property(x => x.Name)
                .HasMaxLength(100).
                IsUnicode(true).
            IsRequired(false);

            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false).
            IsRequired(false);

            builder.Property(x => x.RegisteredOn)
                .IsRequired(true);

            builder.Property(x => x.Birthday)
                .IsRequired(false);

            builder
                .HasMany(x => x.StudentsCourses)
                .WithOne(x => x.Student)
                .HasForeignKey(x => x.StudentId);
        }
    }
}
