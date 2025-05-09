namespace VSoft.Evaluation.WebApi.Features.Students.GetStudent;

public record GetStudentResponse(Guid Id, string Name, string Cpf, DateOnly DateBirth, string Email, string Registration)
{
    public static explicit operator GetStudentResponse?(Application.UseCases.Students.GetStudentUseCase.GetStudentResponse? response)
    => response == null ? null : new GetStudentResponse(response.Id, response.Name, response.Cpf, response.DateBirth, response.Email, response.Registration);
}
