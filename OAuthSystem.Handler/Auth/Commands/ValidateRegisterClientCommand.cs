using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using OAuthSystem.Handler.Infrastructures;
using OAuthSystem.Share.Models;
using OAuthSystem.Share.Options;

namespace OAuthSystem.Handler.Auth.Commands
{
    public class ValidateRegisterClientCommand : ICommand<ValidateRegisterClientCommandResult>
    {
        public string ClientId { get; set; }
        public string RedirectUri { get; set; }
        public string State { get; set; }
    }

    public class ValidateRegisterClientCommandHandler : ICommandHandler<ValidateRegisterClientCommand, ValidateRegisterClientCommandResult>
    {
        private readonly IConfiguration _configuration;
        private readonly OAuthClient _clients;

        public ValidateRegisterClientCommandHandler(IConfiguration configuration,
            IOptions<OAuthClient> clients)
        {
            _configuration = configuration;
            _clients = clients.Value;
        }

        public async Task<ValidateRegisterClientCommandResult> Handle(ValidateRegisterClientCommand request, CancellationToken cancellationToken)
        {
            var result = new ValidateRegisterClientCommandResult();
            if (_clients.Clients.Select(x => x.ClientId).Contains(request.ClientId))
                result.IsSuccess = true;

            return result;
        }
    }

    public class ValidateRegisterClientCommandResult : UnitResult
    {
    }
}
