using VSoft.Evaluation.Application.Common.Interfaces;

namespace VSoft.Evaluation.Application.UseCases.Students.GetStudentDetailsUseCase;

public record GetStudentDetailsCommand(string Cpf) : ICommand
{
    public static implicit operator GetStudentDetailsCommand(string value) =>
        new GetStudentDetailsCommand(value);
}
