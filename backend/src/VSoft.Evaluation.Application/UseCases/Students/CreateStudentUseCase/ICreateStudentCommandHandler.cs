using VSoft.Evaluation.Application.Common.Interfaces;

namespace VSoft.Evaluation.Application.UseCases.Students.CreateStudentUseCase;

public interface ICreateStudentCommandHandler : ICommandHandler<CreateStudentCommand, CreateStudentResponse?>;
