using System.ComponentModel;

public static class EnumHelper
{
    /// <summary>
    ///     获取枚举类型的所有值和它们的描述
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static Dictionary<T, string> GetDescriptions<T>() where T : Enum
    {
        var descriptions = new Dictionary<T, string>();
        foreach (var value in Enum.GetValues(typeof(T)).Cast<T>())
        {
            var fieldInfo = typeof(T).GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(
                typeof(DescriptionAttribute), false);
            descriptions[value] = attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }

        return descriptions;
    }

    public static string GetDescription(Enum value)
    {
        if (value == null) throw new ArgumentNullException(nameof(value));

        var fieldInfo = value.GetType().GetField(value.ToString());

        var attribute = Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute)) as DescriptionAttribute;

        return attribute == null ? value.ToString() : attribute.Description;
    }
}