namespace VSoft.Evaluation.WebApi.Features.Lessons.GetLessonByStudent;

public record GetLessonByStudentResponse(Guid Id, int Number, DateOnly Date, TimeOnly Hour, bool Concluded)
{
}
