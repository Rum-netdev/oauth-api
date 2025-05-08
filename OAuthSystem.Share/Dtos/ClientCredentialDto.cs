namespace OAuthSystem.Share.Dtos;

public class ClientCredentialDto
{
    public string ClientId { get; set; }
    public string ClientName { get; set; }
    public List<string> RedirectUris { get; set; }
    public string ClientSecret { get; set; }
    public List<string> GrantTypes { get; set; }
    public List<string> Scopes { get; set; }
}
