using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data.Configurations
{
    public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.HasKey(x => new
            {
                x.CourseId,
                x.StudentId
            });

            builder
                .Property(x => x.StudentId)
                .IsRequired(true);

            builder
                .Property(x => x.CourseId)
                .IsRequired(true);
        }
    }
}
