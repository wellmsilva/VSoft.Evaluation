using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSoft.Evaluation.Domain.Entities;

namespace VSoft.Evaluation.Infrastructure.Mapping;

internal class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.ToTable("Lessons");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Number);
    }
}
