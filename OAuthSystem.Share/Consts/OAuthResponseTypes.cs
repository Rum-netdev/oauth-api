namespace OAuthSystem.Share.Consts
{
    public static class OAuthResponseTypes
    {
        public const string AuthorizationCode = "authorization_code";

        public static bool IsValidType(string type)
            => type switch
            {
                AuthorizationCode => true,
                _ => false
            };
    }
}
