using Cronofy.Infrastructure.Persistence.Write;
using MediatR;

namespace Cronofy.Infrastructure.Messaging.MediatR.PipelineBehaviours;

public class TransactionPipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
    where TRequest : IRequest<TResponse>
{
    private readonly CronofyWriteDbContext _dbContext;

    public TransactionPipelineBehaviour(CronofyWriteDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        await using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
        var response = await next();
        await _dbContext.Database.CommitTransactionAsync(cancellationToken);

        return response;
    }
}