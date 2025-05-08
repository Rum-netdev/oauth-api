namespace OAuthSystem.Share.Extensions
{
    public static class StringExtensions
    {
        public static string ReplaceOne(this string str, string oldValue, string newValue)
        {
            int index = str.IndexOf(oldValue);
            if (index == -1) return str;

            return str.Substring(0, index) + newValue + str.Substring(index + oldValue.Length);
        }
    }
}
