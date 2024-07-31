 
public static class JsonExtensions
{
    /// <summary>
    /// 字符串反序列化为对象
    /// </summary>
    /// <typeparam name="T">目标对象的类型</typeparam>
    /// <param name="json">JSON字符串</param>
    /// <returns>反序列化后的对象</returns>
    public static T ToDeserializeObject<T>(this string json)
    {
        return System.Text.Json.JsonSerializer.Deserialize<T>(json);
    }

    /// <summary>
    /// 对象序列化为JSON字符串
    /// </summary>
    /// <param name="obj">要序列化的对象</param>
    /// <returns>JSON字符串</returns>
    public static string ToJson(this object obj)
    {
        return System.Text.Json.JsonSerializer.Serialize(obj);
    }
}
