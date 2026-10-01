namespace TacheApp.Application.Common.Interfaces
{
    public interface IQueryHandler<TQuery, TResult>
    {
        Task<TResult> HandleAsync(TQuery query, CancellationToken ct = default);
    }
}
