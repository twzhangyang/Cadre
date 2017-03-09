namespace CadreManagement.Core.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string @string)
        {
            return string.IsNullOrEmpty(@string);
        }

        public static string FormatWith(this string @string,params object[] parameters)
        {
            return string.Format(@string, parameters);
        }
    }
}