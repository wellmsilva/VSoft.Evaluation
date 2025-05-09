using FluentValidation;

namespace VSoft.Evaluation.WebApi.Features.Lessons.ScheduleLesson;

public class ScheduleLessonRequestValidator : AbstractValidator<ScheduleLessonRequest>
{
    public ScheduleLessonRequestValidator()
    {
        RuleFor(p => p.Date)
            .Must(x => x >= DateOnly.FromDateTime(DateTime.Now))
            .WithMessage("Date cannot be less than actual date");

        RuleFor(p => p.StudentId)
            .NotEmpty();
    }
}
