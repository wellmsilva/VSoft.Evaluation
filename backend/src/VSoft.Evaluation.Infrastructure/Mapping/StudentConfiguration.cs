using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSoft.Evaluation.Domain.Entities;
using VSoft.Evaluation.Domain.ValueObjects;

namespace VSoft.Evaluation.Infrastructure.Mapping;

internal class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {

        builder.HasKey(p => p.Id);
        builder.Property(si => si.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Cpf)
            .HasConversion(p => p.Value, p => p)
            .IsRequired().HasMaxLength(11);
        builder.Property(p => p.Email)
            .HasConversion(p => p.Value, p => p)
            .IsRequired().HasMaxLength(100);
        builder.Property(p => p.Registration).IsRequired().HasMaxLength(100);

        builder.HasMany(x => x.Lessons)
            .WithOne(x => x.Student)
            .HasForeignKey(x => x.StudentId);

        builder.Ignore(x => x.Progress);
        builder.Ignore(x => x.CanSchedule);
        builder.Ignore(x => x.CanLessonsPractical);
    }
}
