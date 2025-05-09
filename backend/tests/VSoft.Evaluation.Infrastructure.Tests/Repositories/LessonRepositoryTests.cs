using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VSoft.Evaluation.Domain.Entities;
using VSoft.Evaluation.Domain.Repositories;
using VSoft.Evaluation.Infrastructure.Contexts;
using VSoft.Evaluation.Infrastructure.Repositories;

namespace VSoft.Evaluation.Infrastructure.Tests.Repositories;

public class LessonRepositoryTests : RepositoryBaseTests
{


    [Fact]
    public async Task AddItemToLesson_Should_Add_Item()
    {
        // Arrange
        using var scope = _serviceProvider.CreateScope();

        var scopedServices = scope.ServiceProvider;
        var manager = scopedServices.GetRequiredService<ILessonRepository>();
        var dbContext = scopedServices.GetRequiredService<DefaultContext>();

        var item = new Lesson(Guid.NewGuid(), 0, DateOnly.FromDateTime(DateTime.Now), TimeOnly.FromDateTime(DateTime.Now));

        // Act
        var entity = await manager.CreateAsync(item, default);

        // Assert
        var addedItem = dbContext.Lessons.Find(item.Id);
        Assert.NotNull(addedItem);
        Assert.Equal(item.StudentId, addedItem.StudentId);
    }

    [Fact]
    public async Task GetByIdLesson_Should_Get_Item()
    {
        // Arrange
        using var scope = _serviceProvider.CreateScope();

        var scopedServices = scope.ServiceProvider;
        var manager = scopedServices.GetRequiredService<ILessonRepository>();
        var dbContext = scopedServices.GetRequiredService<DefaultContext>();

        var item = new Lesson(Guid.NewGuid(), 0, DateOnly.FromDateTime(DateTime.Now), TimeOnly.FromDateTime(DateTime.Now));
        var entity = await manager.CreateAsync(item, default);

        // Act
        var lesson = manager.GetById(item.Id);

        // Assert
        var addedItem = dbContext.Lessons.Find(item.Id);
        Assert.NotNull(addedItem);
        Assert.Equal(item.StudentId, addedItem.StudentId);
    }

    [Fact]
    public async Task GetLessonByStudent_Should_Get_Item()
    {
        // Arrange
        using var scope = _serviceProvider.CreateScope();

        var scopedServices = scope.ServiceProvider;
        var manager = scopedServices.GetRequiredService<ILessonRepository>();
        var dbContext = scopedServices.GetRequiredService<DefaultContext>();

        var item = new Lesson(Guid.NewGuid(), 0, DateOnly.FromDateTime(DateTime.Now), TimeOnly.FromDateTime(DateTime.Now));
        var entity = await manager.CreateAsync(item, default);

        // Act
        var lesson = manager.GetLessonByStudent(item.StudentId);

        // Assert
        var addedItem = dbContext.Lessons.FirstOrDefault(x => x.StudentId ==  item.StudentId);
        Assert.NotNull(addedItem);
        Assert.Equal(item.StudentId, addedItem.StudentId);
    }

    [Fact]
    public async Task UpdateLesson_Should_Update_Item()
    {
        // Arrange
        using var scope = _serviceProvider.CreateScope();

        var scopedServices = scope.ServiceProvider;
        var manager = scopedServices.GetRequiredService<ILessonRepository>();
        var dbContext = scopedServices.GetRequiredService<DefaultContext>();

        var item = new Lesson(Guid.NewGuid(), 0, DateOnly.FromDateTime(DateTime.Now), TimeOnly.FromDateTime(DateTime.Now));
        var entity = await manager.CreateAsync(item, default);
        entity.Conclude();
        // Act
        var lesson = await manager.UpdateAsync(entity,default);

        // Assert
        var addedItem = dbContext.Lessons.FirstOrDefault(x => x.StudentId == item.StudentId);
        Assert.NotNull(addedItem);
        Assert.Equal(entity.Concluded, lesson.Concluded);
    }
}
