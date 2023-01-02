
namespace Cooper.Core.Extensions
{
    public static class StringExtensions
    {
        public static int ToInt(this string str)
        {
            return Convert.ToInt32(str);
        }

        public static decimal ToDecimal(this string str)
        {
            return Convert.ToDecimal(str);
        }
    }
}
