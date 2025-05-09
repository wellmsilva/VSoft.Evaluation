using VSoft.Evaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VSoft.Evaluation.Domain.ValueObjects;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace VSoft.Evaluation.Infrastructure.Contexts;

internal class DefaultContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<User> Users { get; set; }

    public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
    {        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ConfigureWarnings(warnings =>
               warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    }

}