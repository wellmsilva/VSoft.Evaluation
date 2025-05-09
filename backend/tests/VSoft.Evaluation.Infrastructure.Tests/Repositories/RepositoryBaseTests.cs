using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VSoft.Evaluation.Domain.Repositories;
using VSoft.Evaluation.Infrastructure.Contexts;
using VSoft.Evaluation.Infrastructure.Repositories;

namespace VSoft.Evaluation.Infrastructure.Tests.Repositories;

public abstract class RepositoryBaseTests
{
    protected readonly ServiceProvider _serviceProvider;

    public RepositoryBaseTests()
    {
        var services = new ServiceCollection();

        // Using In-Memory database for testing
        services.AddDbContext<DefaultContext>(options =>
            options.UseInMemoryDatabase("TestDb"));

        services.AddScoped<ILessonRepository, LessonRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        _serviceProvider = services.BuildServiceProvider();
    }
}
