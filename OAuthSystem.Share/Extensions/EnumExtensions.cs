using System.ComponentModel;

namespace OAuthSystem.Share.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value) 
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if(descriptionAttributes.Any())
                return descriptionAttributes[0].Description;

            return value.ToString();
        }
    }
}
