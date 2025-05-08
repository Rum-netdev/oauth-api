using OAuthSystem.Data.Entities;
using OAuthSystem.Handler.Auth.Commands;

namespace OAuthSystem.Handler.Profiles
{
    public static class TokenProfile
    {
        public static AuthorizeCommandResult MapToAuthorizeCommandResult(this ApplicationCode applicationCode)
        {
            return new AuthorizeCommandResult()
            {
                Code = applicationCode.Code
            };
        }
    }
}
