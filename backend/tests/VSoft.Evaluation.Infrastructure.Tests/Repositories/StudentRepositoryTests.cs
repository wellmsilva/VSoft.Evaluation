using FizzWare.NBuilder;
using Microsoft.Extensions.DependencyInjection;
using VSoft.Evaluation.Domain.Entities;
using VSoft.Evaluation.Domain.Repositories;
using VSoft.Evaluation.Domain.ValueObjects;
using VSoft.Evaluation.Infrastructure.Contexts;

namespace VSoft.Evaluation.Infrastructure.Tests.Repositories;

public class StudentRepositoryTests : RepositoryBaseTests
{

    [Fact]
    public async Task AddItemToStudent_Should_Add_Item()
    {
        // Arrange
        using var scope = _serviceProvider.CreateScope();

        var scopedServices = scope.ServiceProvider;
        var manager = scopedServices.GetRequiredService<IStudentRepository>();
        var dbContext = scopedServices.GetRequiredService<DefaultContext>();

        var id = Guid.NewGuid();
        var item = Builder<Student>.CreateNew()
            .With(x => x.Id, id)
            .With(x => x.Cpf, new Cpf("13245685200"))
            .With(x => x.Email, new Email("teste@teste.com"))
            .Build();

        // Act
        var entity = await manager.CreateAsync(item, default);

        // Assert
        var addedItem = dbContext.Students.Find(item.Id);
        Assert.NotNull(addedItem);
        Assert.Equal(item.Id, addedItem.Id);
    }

    [Fact]
    public async Task DeleteItemToStudent_Should_Delete_Item()
    {
        // Arrange
        using var scope = _serviceProvider.CreateScope();

        var scopedServices = scope.ServiceProvider;
        var manager = scopedServices.GetRequiredService<IStudentRepository>();
        var dbContext = scopedServices.GetRequiredService<DefaultContext>();

        var id = Guid.NewGuid();
        var item = Builder<Student>.CreateNew()
            .With(x => x.Id, id)
            .With(x => x.Cpf, new Cpf("13245685200"))
            .With(x => x.Email, new Email("teste@teste.com"))
            .Build();

        var entity = await manager.CreateAsync(item, default);
        // Act
        var deleted = await manager.Delete(entity!, default);

        // Assert
        var addedItem = await manager.GetById(item.Id, default);
        Assert.Null(addedItem);
    }

    [Fact]
    public async Task GetAllStudent_Should_GetAll()
    {
        // Arrange
        using var scope = _serviceProvider.CreateScope();

        var scopedServices = scope.ServiceProvider;
        var manager = scopedServices.GetRequiredService<IStudentRepository>();
        var dbContext = scopedServices.GetRequiredService<DefaultContext>();

        var id = Guid.NewGuid();
        var item = Builder<Student>.CreateNew()
            .With(x => x.Id, id)
            .With(x => x.Cpf, new Cpf("13245685200"))
            .With(x => x.Email, new Email("teste@teste.com"))
            .Build();

        var entity = await manager.CreateAsync(item, default);
        // Act
        var students =  manager.GetAll(null);

        // Assert        
        Assert.NotEmpty(students);
    }
}
