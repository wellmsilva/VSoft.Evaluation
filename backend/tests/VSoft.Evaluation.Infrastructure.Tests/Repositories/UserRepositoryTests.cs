using FizzWare.NBuilder;
using Microsoft.Extensions.DependencyInjection;
using VSoft.Evaluation.Domain.Entities;
using VSoft.Evaluation.Domain.Repositories;
using VSoft.Evaluation.Domain.ValueObjects;
using VSoft.Evaluation.Infrastructure.Contexts;

namespace VSoft.Evaluation.Infrastructure.Tests.Repositories;

public class UserRepositoryTests : RepositoryBaseTests
{
    [Fact]
    public async Task GetAllStudent_Should_GetAll()
    {
        // Arrange
        using var scope = _serviceProvider.CreateScope();

        var scopedServices = scope.ServiceProvider;
        var manager = scopedServices.GetRequiredService<IUserRepository>();
        var dbContext = scopedServices.GetRequiredService<DefaultContext>();
        var userName = "13245685200";

        var item = Builder<User>.CreateNew()
            .With(x => x.Cpf, userName)
            .With(x => x.UserName, userName)
            .Build();

        var entity = await dbContext.Users.AddAsync(item, default);
        await dbContext.SaveChangesAsync();
        // Act
        var user = manager.GetByUserName(userName, default);

        // Assert        
        Assert.NotNull(user);
    }
}
