using MediatR;

namespace OAuthSystem.Handler.Infrastructures;

public interface IQuery<TQueryResult> : IRequest<TQueryResult>
{
}

public interface IQuery : IRequest
{
}

public interface IQueryHandler<TQuery, TQueryResult> : IRequestHandler<TQuery, TQueryResult> where TQuery : IQuery<TQueryResult>
{
}

public interface IQueryHandler<TQuery> : IRequestHandler<TQuery> where TQuery : IQuery
{
}
