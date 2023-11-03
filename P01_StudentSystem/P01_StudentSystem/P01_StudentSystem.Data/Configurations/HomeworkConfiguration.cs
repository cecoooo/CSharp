using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data.Configurations
{
    public class HomeworkConfiguration : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> builder)
        {
            builder.HasKey(x => x.HomeworkId);

            builder.Property(x => x.Content)
                .IsRequired(true)
                .IsUnicode(true);

            builder.Property(x => x.ContentType)
                .IsRequired(true);

            builder.Property(x => x.SubmissionTime)
                .IsRequired(true);

            builder.Property(x => x.StudentId)
                .IsRequired(true);

            builder.Property(x => x.CourseId)
                .IsRequired(true);

            builder
                .HasOne(x => x.Student)
                .WithMany(x => x.Homeworks)
                .HasForeignKey(x => x.StudentId);

            builder
                .HasOne(x => x.Course)
                .WithMany(x => x.Homeworks)
                .HasForeignKey(x => x.CourseId);
        }
    }
}
