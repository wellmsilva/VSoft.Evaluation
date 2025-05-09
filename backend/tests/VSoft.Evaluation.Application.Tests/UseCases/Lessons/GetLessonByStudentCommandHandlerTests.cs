using FizzWare.NBuilder;
using Moq;
using VSoft.Evaluation.Application.UseCases.Lessons.ConcludeLessonUseCase;
using VSoft.Evaluation.Application.UseCases.Lessons.GetLessonByStudentUseCase;
using VSoft.Evaluation.Domain.Entities;
using VSoft.Evaluation.Domain.Repositories;

namespace VSoft.Evaluation.Application.Tests.UseCases.Lessons;

public class GetLessonByStudentCommandHandlerTests
{
    private Mock<ILessonRepository> _lessonRepository;


    public GetLessonByStudentCommandHandlerTests()
    {
        _lessonRepository = new Mock<ILessonRepository>();
    }

    [Fact]
    public async Task HandleCommand_GetLessonByStudent_Sucess()
    {
        var lessons = Builder<Lesson>.CreateListOfSize(6)
                .All().With(x => x.Concluded, true)
            .Build();

        _lessonRepository.Setup(x => x.GetLessonByStudent(It.IsAny<Guid>())).Returns(lessons);

        var commandHandler = new GetLessonByStudentCommandHandler(_lessonRepository.Object);

        var command = new GetLessonByStudentCommand(Guid.NewGuid());
        var response = await commandHandler.Handle(command, default);

        Assert.NotNull(response);
        Assert.NotNull(response.Items);
    }
}
