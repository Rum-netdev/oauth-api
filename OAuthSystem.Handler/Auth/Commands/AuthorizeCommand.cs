using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using OAuthSystem.Data;
using OAuthSystem.Data.Entities;
using OAuthSystem.Handler.Infrastructures;
using OAuthSystem.Handler.Profiles;
using OAuthSystem.Share.Consts;
using OAuthSystem.Share.Extensions;
using OAuthSystem.Share.Enums;
using OAuthSystem.Share.Exceptions;
using OAuthSystem.Share.Helpers;
using OAuthSystem.Share.Options;

namespace OAuthSystem.Handler.Auth.Commands
{
    public class AuthorizeCommand : ICommand<AuthorizeCommandResult>
    {
        public required string ClientId { get; set; }
        public required string RedirectUri { get; set; }
        public required string ResponseType { get; set; }
        public required string Scope { get; set; }
        public string State { get; set; }
    }

    public class AuthorizeCommandHandler : ICommandHandler<AuthorizeCommand, AuthorizeCommandResult>
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly OAuthClient _clients;
        private readonly JwtConfiguration _jwtConfig;

        public AuthorizeCommandHandler(
            ApplicationDbContext context,
            IConfiguration configuration,
            IOptions<OAuthClient> clientOption,
            IOptions<JwtConfiguration> jwtConfig
        )
        {
            _context = context;
            _configuration = configuration;
            _clients = clientOption.Value;
            _jwtConfig = jwtConfig.Value;
        }

        public async Task<AuthorizeCommandResult> Handle(AuthorizeCommand request, CancellationToken cancellationToken)
        {
            if (!IsExistingClientId(request.ClientId))
                throw new DomainException("invalid", "invalid or missing client_id");
            if (IsValidResponseType(request.ResponseType))
                throw new DomainException("invalid", "invalid or missing response_type");

            ApplicationCode code = GenerateCode(CodeIssues.OAuth.GetDescription());
            _context.ApplicationCodes.Add(code);
            await _context.SaveChangesAsync(cancellationToken);

            return code.MapToAuthorizeCommandResult();
        }

        private bool IsExistingClientId(string clientId)
            => _clients.Clients.Select(x => x.ClientId).Any(x => x == clientId);

        private bool IsValidResponseType(string responseType)
            => OAuthResponseTypes.IsValidType(responseType);

        private ApplicationCode GenerateCode(string issueReason)
        {
            return new ApplicationCode()
            {
                Code = CodeGenerator.GenerateAuthCode(),
                ExpiredAt = DateTime.UtcNow.AddMinutes(_jwtConfig.TokenLifeTime),
                IssueReason = issueReason
            };
        }
    }

    public class AuthorizeCommandResult
    {
        public required string Code { get; set; }
        public string State { get; set; }
    }
}
