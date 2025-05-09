using MassTransit;
using Microsoft.Extensions.Logging;

namespace VSoft.Evaluation.Application.UseCases.Lessons.ConcludeLessonUseCase;

internal sealed class ConcludedLessonConsumer : IConsumer<ConcludeLessonCommand>
{
    private readonly ILogger<ConcludedLessonConsumer> _logger;

    public ConcludedLessonConsumer(ILogger<ConcludedLessonConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<ConcludeLessonCommand> context)
    {
        _logger.LogInformation("Concluded Lesson Id {Id}", context.Message.Id);

        return Task.CompletedTask;
    }
}
