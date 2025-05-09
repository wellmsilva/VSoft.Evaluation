namespace VSoft.Evaluation.WebApi.Features.Students.DeleteStudent;

public record DeleteStudentResponse(Guid Id)
{
    public static implicit operator DeleteStudentResponse(Application.UseCases.Students.DeleteStudentUseCase.DeleteStudentResponse request)
       => new DeleteStudentResponse(request.Id);
}
