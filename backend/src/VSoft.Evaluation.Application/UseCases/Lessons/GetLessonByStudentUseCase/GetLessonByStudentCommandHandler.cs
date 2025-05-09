using VSoft.Evaluation.Domain.Repositories;

namespace VSoft.Evaluation.Application.UseCases.Lessons.GetLessonByStudentUseCase;

internal class GetLessonByStudentCommandHandler : IGetLessonByStudentCommandHandler
{
    private readonly ILessonRepository _lessonRepository;

    public GetLessonByStudentCommandHandler(ILessonRepository lessonRepository)
    {
        _lessonRepository = lessonRepository;
    }

    public async Task<GetLessonByStudentResponse> Handle(GetLessonByStudentCommand command, CancellationToken cancellationToken)
    {
        var entities =  _lessonRepository.GetLessonByStudent(command.Id);
        var response = entities.Select(x => (GetLessonByStudentItemResponse)x);
              
        return await Task.FromResult(new GetLessonByStudentResponse(response));
    }
}
