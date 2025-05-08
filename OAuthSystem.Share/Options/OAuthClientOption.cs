using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using OAuthSystem.Share.Dtos;

namespace OAuthSystem.Share.Options
{
    public class OAuthClientOption : IConfigureOptions<OAuthClient>
    {
        private const string SECTION_NAME = "OAuthClients";
        private readonly IConfiguration _configuration;

        public OAuthClientOption(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(OAuthClient options)
        {
            _configuration.GetSection(SECTION_NAME)
                .Bind(options);
        }
    }

    public class OAuthClient
    {
        public List<ClientCredentialDto> Clients { get; set; } = new();
    }
}
