using FizzWare.NBuilder;
using MassTransit;
using Microsoft.Extensions.Logging;
using Moq;
using VSoft.Evaluation.Application.UseCases.Lessons.ConcludeLessonUseCase;
using VSoft.Evaluation.Domain.Entities;
using VSoft.Evaluation.Domain.Repositories;

namespace VSoft.Evaluation.Application.Tests.UseCases.Lessons;

public class ConcludeLessonCommandHandlerTests
{

    private Mock<ILessonRepository> _lessonRepository;
    private Mock<ILogger<ConcludeLessonCommandHandler>> _logger;
    private Mock<IBus> _bus;

    public ConcludeLessonCommandHandlerTests()
    {
        _lessonRepository = new Mock<ILessonRepository>();
        _logger = new Mock<ILogger<ConcludeLessonCommandHandler>>();
        _bus = new Mock<IBus>();
    }

    [Fact]
    public async Task HandleCommand_ConcludeLesson_Sucess()
    {
        var lesson = Builder<Lesson>.CreateNew()
            .With(x => x.Concluded, false)
            .Build();

        _lessonRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(lesson);
        _lessonRepository.Setup(x => x.UpdateAsync(It.IsAny<Lesson>(), It.IsAny<CancellationToken>())).ReturnsAsync(lesson);

        var command = new ConcludeLessonCommand(Guid.NewGuid());
        var commandHandler = new ConcludeLessonCommandHandler(_lessonRepository.Object, _logger.Object, _bus.Object);
        var response = await commandHandler.Handle(command);
        Assert.NotNull(response);
    }


    [Fact]
    public async Task HandleCommand_ConcludeLesson_Not_Stutend()
    {
        var lesson = Builder<Lesson>.CreateNew()
            .With(x => x.Concluded, false)
            .Build();

        _lessonRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(() => null);
        _lessonRepository.Setup(x => x.UpdateAsync(It.IsAny<Lesson>(), It.IsAny<CancellationToken>())).ReturnsAsync(lesson);

        var command = new ConcludeLessonCommand(Guid.NewGuid());
        var commandHandler = new ConcludeLessonCommandHandler(_lessonRepository.Object, _logger.Object, _bus.Object);

        await Assert.ThrowsAsync<ArgumentException>(async () => await commandHandler.Handle(command));
    }
}
