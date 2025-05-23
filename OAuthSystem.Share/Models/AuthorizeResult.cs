namespace OAuthSystem.Share.Models
{
    public class AuthorizeResult
    {
        public string Code { get; set; }
        public string RedirectUri { get; set; }

        public AuthorizeResult()
        {
        }

        public AuthorizeResult(string code, string redirectUri)
        {
            this.Code = code;
            this.RedirectUri = redirectUri;
        }
    }
}
