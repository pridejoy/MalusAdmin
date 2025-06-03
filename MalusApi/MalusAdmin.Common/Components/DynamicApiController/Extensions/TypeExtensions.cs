using System.Reflection;

internal static class TypeExtensions
{
    public static TypeInfo GetTypeInfo(this Type type)
    {
        return (TypeInfo)type;
    }
}