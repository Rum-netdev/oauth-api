using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OAuthSystem.Handler.Auth.Commands;
using OAuthSystem.Handler.Infrastructures;
using OAuthSystem.Share.Models;

namespace OAuthSystem.Controllers;

/// <summary>
/// For OAuth only
/// </summary>
[ApiController]
public class AuthController(IBroker broker) : Controller
{
    private readonly IBroker _broker = broker;

    [HttpPost("/authorize")]
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

        return Ok(new AuthorizeResult(result.Code, redirectUri));
    }

    [HttpGet("/authorize")]
    public async Task<IActionResult> Authorize([FromQuery] ValidateRegisterClientCommand request)
    {
        var result = await _broker.CommandAsync(request);
        if (!result.IsSuccess)
        {
            return BadRequest("invalid client or redirect_uri");
        }

        ViewData[nameof(ValidateRegisterClientCommand.ClientId)] = request.ClientId;
        ViewData[nameof(ValidateRegisterClientCommand.RedirectUri)] = request.RedirectUri;
        ViewData[nameof(ValidateRegisterClientCommand.State)] = request.State;

        return Redirect("/login");
    }

    [HttpGet("/login")]
    public IActionResult Login()
    {
        return View();
    }

}
