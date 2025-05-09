using Microsoft.Extensions.Logging;
using VSoft.Evaluation.Application.Common.Interfaces;
using VSoft.Evaluation.Application.Common;
using VSoft.Evaluation.Domain.Repositories;
using MassTransit;

namespace VSoft.Evaluation.Application.UseCases.Lessons.ScheduleLessonUseCase;

internal class ScheduleLessonCommandHandler : IScheduleLessonCommandHandler
{
    private readonly ILessonRepository _repository;
    private readonly ILogger<ScheduleLessonCommandHandler> _logger;
    private readonly IBus _bus;
    private readonly IStudentRepository _stutendRepository;

    public ScheduleLessonCommandHandler(ILessonRepository repository, ILogger<ScheduleLessonCommandHandler> logger, IBus bus, IStudentRepository stutendRepository)
    {
        _repository = repository;
        _logger = logger;
        _bus = bus;
        _stutendRepository = stutendRepository;
    }
    public async Task<ScheduleLessonResponse?> Handle(ScheduleLessonCommand command, CancellationToken cancellationToken)
    {
        var student = await _stutendRepository.GetById(command.StudentId, cancellationToken);
        if (student?.CanSchedule != true) {

            _logger.LogInformation("Scheduled Lesson deny");
            throw new Exception("Scheduled Lesson deny");
        }

        var entity = await _repository.CreateAsync(command, cancellationToken);
        if (entity == null)
        {
            _logger.LogInformation("Scheduled Lesson success");
            return null;
        }

        _logger.LogInformation("Scheduled Lesson success");

        await _bus.Publish(new
        {
            NotificationDate = DateTime.UtcNow,
            NotificationMessage = "Scheduled Lesson success",
            NotificationContent = command.StudentId,
            NotificationType = NotificationType.Push
        });

        return entity;
    }
}
