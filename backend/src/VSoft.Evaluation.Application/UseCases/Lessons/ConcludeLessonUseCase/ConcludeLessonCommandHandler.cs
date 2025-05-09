using MassTransit;
using Microsoft.Extensions.Logging;
using VSoft.Evaluation.Application.Common;
using VSoft.Evaluation.Domain.Repositories;

namespace VSoft.Evaluation.Application.UseCases.Lessons.ConcludeLessonUseCase;

public sealed class ConcludeLessonCommandHandler : IConcludeLessonCommandHandler
{
   
    private readonly ILessonRepository _lessonRepository;
    private readonly ILogger<ConcludeLessonCommandHandler> _logger;
    private readonly IBus _bus;


    public ConcludeLessonCommandHandler(ILessonRepository lessonRepository, ILogger<ConcludeLessonCommandHandler> logger, IBus bus)
    {
        _lessonRepository = lessonRepository;
        _logger = logger;
        _bus = bus;
    }

    public async Task<ConcludeLessonResponse> Handle(ConcludeLessonCommand command, CancellationToken cancellationToken = default)
    {

        var lesson = _lessonRepository.GetById(command.Id);
        if (lesson == null)
        {
            _logger.LogError("Aula ID({Id}) não encontrada", command.Id);
            throw new ArgumentException("command.Id");
        }

        lesson.Conclude();
        var entity = await _lessonRepository.UpdateAsync(lesson, cancellationToken);


        _logger.LogInformation("Aula ID {Id} concluída com sucesso", command.Id);
        await _bus.Publish(command, cancellationToken);
              
        return new ConcludeLessonResponse(entity.Id, entity.StudentId, entity.Number, entity.Date, entity.Hour);
    }
}
