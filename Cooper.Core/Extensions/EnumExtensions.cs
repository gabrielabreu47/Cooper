using System.ComponentModel;

namespace Cooper.Core.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            if (value == null) return "";

            var result = Convert.ToString(value);
            var field = value.GetType().GetField(result);

            if(field == null) throw new ArgumentException("Value does not exists in the specified enum", nameof(value));

            return Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is not DescriptionAttribute attribute 
                ? result : attribute.Description;
        }

        public static int ToInt(this Enum value)
        {
            return Convert.ToInt32(value);
        }

        public static char ToChar(this Enum value)
        {
            return Convert.ToChar(value);
        }
    }
}
