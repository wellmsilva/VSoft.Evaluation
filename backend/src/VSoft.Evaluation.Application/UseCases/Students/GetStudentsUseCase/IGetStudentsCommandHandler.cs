using VSoft.Evaluation.Application.Common.Interfaces;

namespace VSoft.Evaluation.Application.UseCases.Students.GetStudentsUseCase;

public interface IGetStudentsCommandHandler : ICommandHandler<GetStudentsCommand, GetStudentsResponse>;
