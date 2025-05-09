namespace VSoft.Evaluation.Application.Common.Interfaces;

public interface ICommandHandler<T, R> 
    where T : ICommand
    where R : IResponse?
{
    public abstract Task<R> Handle(T command, CancellationToken cancellationToken = default);
}
