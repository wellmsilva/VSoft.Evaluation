using VSoft.Evaluation.Application.Common.Interfaces;
using VSoft.Evaluation.Domain.Entities;

namespace VSoft.Evaluation.Application.UseCases.Lessons.ScheduleLessonUseCase;

public record ScheduleLessonCommand(Guid StudentId,int Numero, DateOnly Date, TimeOnly Hour) : ICommand
{
    public static implicit operator Lesson(ScheduleLessonCommand command)
        => new Lesson(command.StudentId, command.Numero,  command.Date, command.Hour);
}
