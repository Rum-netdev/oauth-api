using OAuthSystem.Share.Extensions;

namespace OAuthSystem.Share.Exceptions
{
    public class DomainException : Exception
    {
        public const string ERROR_MESSAGE = $"[{nameof(Error)}]: {nameof(ErrorDescription)}.";
        public string Error { get; set; }
        public string ErrorDescription { get; set; }

        public DomainException(string error, string errorDescription)
        {
            Error = error;
            ErrorDescription = errorDescription;
        }

        public override string ToString()
        {
            return ERROR_MESSAGE
                .ReplaceOne(nameof(Error), Error)
                .ReplaceOne(nameof(ErrorDescription), ErrorDescription);
        }
    }
}
