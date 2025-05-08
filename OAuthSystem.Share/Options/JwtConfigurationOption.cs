using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace OAuthSystem.Share.Options
{
    public class JwtConfigurationOption : IConfigureOptions<JwtConfiguration>
    {
        public const string SECTION_NAME = "JwtConfigs";
        private readonly IConfiguration _configuration;

        public JwtConfigurationOption(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(JwtConfiguration options)
        {
            _configuration.GetSection(SECTION_NAME)
                .Bind(options);
        }
    }

    public class JwtConfiguration
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecretKey { get; set; }
        public int TokenLifeTime { get; set; }
    }
}
