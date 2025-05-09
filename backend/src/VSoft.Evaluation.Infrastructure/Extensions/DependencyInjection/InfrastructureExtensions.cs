using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using VSoft.Evaluation.Domain.Repositories;
using VSoft.Evaluation.Infrastructure.Contexts;
using VSoft.Evaluation.Infrastructure.Repositories;

namespace VSoft.Evaluation.Infrastructure.Extensions.DependencyInjection;

[ExcludeFromCodeCoverage]
public static class InfrastructureExtensions
{
    /// <summary>
    /// Configures the Infrastructure and connect to a PostgreSQL database with Npgsql.
    /// </summary>
    /// <param name="services">Collection of service</param>
    /// <param name="configuration">Configuration properties than contains the ConnectionString "DefaultConnection" </param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DefaultContext>(options =>
        {
            var conn = configuration.GetConnectionString("DefaultConnection");
            options.UseNpgsql(conn, b => b.MigrationsAssembly("VSoft.Evaluation.Infrastructure"));
        });

        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ILessonRepository, LessonRepository>();

        return services;
    }
}
