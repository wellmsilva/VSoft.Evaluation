using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSoft.Evaluation.Domain.Entities;
using VSoft.Evaluation.Domain.ValueObjects;

namespace VSoft.Evaluation.Infrastructure.Mapping;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(x => x.Id);
        builder.Property(si => si.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
        builder.Property(p => p.UserName).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Password).IsRequired().HasMaxLength(256);
        builder.Property(p => p.Email).HasMaxLength(100);
        builder.Property(p => p.Role).IsRequired().HasMaxLength(10);

        builder.HasData(
            new User("Admin", "12345678900", "12345678900", "12345678900", Domain.Enums.UserRole.CFC),
            new User("Student", "12345678901", "12345678901", "12345678901", Domain.Enums.UserRole.Student)
        );

    }
}
