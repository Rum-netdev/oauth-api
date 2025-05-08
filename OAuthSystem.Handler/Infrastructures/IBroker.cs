using MediatR;

namespace OAuthSystem.Handler.Infrastructures
{
    public interface IBroker
    {
        Task<TCommandResult> CommandAsync<TCommandResult>(ICommand<TCommandResult> command);
        Task<TCommandResult> CommandAsync<TCommandResult>(ICommand<TCommandResult> command, CancellationToken cancellationToken);


        Task CommandAsync<TCommand>(ICommand command);
        Task CommandAsync<TCommand>(ICommand command, CancellationToken cancellationToken);


        Task<TQueryResult> QueryAsync<TQueryResult>(IQuery<TQueryResult> query);
        Task<TQueryResult> QueryAsync<TQueryResult>(IQuery<TQueryResult> query, CancellationToken cancellationToken);


        Task QueryAsync<TQuery>(IQuery query);
        Task QueryAsync<TQuery>(IQuery query, CancellationToken cancellationToken);

        Task PublishEvent(INotification notifcation);
    }

    public class Broker(IMediator mediator) : IBroker
    {
        public readonly IMediator _mediator = mediator;

        public async Task<TCommandResult> CommandAsync<TCommandResult>(ICommand<TCommandResult> command)
            => await _mediator.Send(command);

        public async Task<TCommandResult> CommandAsync<TCommandResult>(ICommand<TCommandResult> command, CancellationToken cancellationToken)
            => await _mediator.Send(command, cancellationToken);

        public async Task CommandAsync<TCommand>(ICommand command)
            => await _mediator.Send(command);

        public async Task CommandAsync<TCommand>(ICommand command, CancellationToken cancellationToken)
            => await _mediator.Send(command, cancellationToken);

        public async Task PublishEvent(INotification notifcation)
            => await _mediator.Publish(notifcation);

        public async Task<TQueryResult> QueryAsync<TQueryResult>(IQuery<TQueryResult> query)
            => await _mediator.Send(query);

        public async Task<TQueryResult> QueryAsync<TQueryResult>(IQuery<TQueryResult> query, CancellationToken cancellationToken)
            => await _mediator.Send(query, cancellationToken);

        public async Task QueryAsync<TQuery>(IQuery query)
            => await _mediator.Send(query);

        public async Task QueryAsync<TQuery>(IQuery query, CancellationToken cancellationToken)
            => await _mediator.Send(query, cancellationToken);
    }
}
