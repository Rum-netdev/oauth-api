using Microsoft.AspNetCore.Mvc;
using OAuthSystem.Handler.Auth.Commands;
using OAuthSystem.Handler.Infrastructures;

namespace OAuthSystem.Controllers;

/// <summary>
/// For OAuth only
/// </summary>
[ApiController]
public class AuthController(IBroker broker) : Controller
{
    private readonly IBroker _broker = broker;

    [HttpGet("/authorize")]
    public async Task<IActionResult> Authorize(string clientId, string redirectUri, string responseType, string scope, string state)
    {
        var result = await _broker.CommandAsync(new AuthorizeCommand()
        {
            ClientId = clientId,
            RedirectUri = redirectUri,
            ResponseType = responseType,
            Scope = scope,
            State = state
        });

        return Redirect($"{redirectUri}?code={result.Code}&state={result.State}");
    }
}
