using MassTransit;
using Microsoft.Extensions.Logging;
using VSoft.Evaluation.Domain.Repositories;

namespace VSoft.Evaluation.Application.UseCases.Lessons.ConcludeLessonUseCase;

internal sealed class ConcludedLessonConsumer : IConsumer<ConcludeLessonCommand>
{
    private readonly ILogger<ConcludedLessonConsumer> _logger;
    private readonly ILessonRepository _lessonRepository;

    public ConcludedLessonConsumer(ILogger<ConcludedLessonConsumer> logger, ILessonRepository lessonRepository)
    {
        _logger = logger;
        _lessonRepository = lessonRepository;
    }

    public Task Consume(ConsumeContext<ConcludeLessonCommand> context)
    {
        _logger.LogInformation("Concluded Lesson Id {Id}", context.Message.Id);
        if (!VerifyCanLessonsPractical(context))
            return Task.CompletedTask;

        _logger.LogInformation("DETRAN: Student able to take practical lessons.");

        return Task.CompletedTask;
    }

    private bool VerifyCanLessonsPractical(ConsumeContext<ConcludeLessonCommand> context)
    {
        var lesson = _lessonRepository.GetById(context.Message.Id);
        return lesson?.Student?.CanLessonsPractical == true;
    }
}
