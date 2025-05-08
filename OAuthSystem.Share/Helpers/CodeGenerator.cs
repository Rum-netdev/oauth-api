using System.Security.Cryptography;
using Microsoft.AspNetCore.WebUtilities;

namespace OAuthSystem.Share.Helpers
{
    public class CodeGenerator
    {
        public static string GenerateAuthCode(int length = 32)
        {
            var bytes = RandomNumberGenerator.GetBytes(length);
            return WebEncoders.Base64UrlEncode(bytes);
        }

    }
}
