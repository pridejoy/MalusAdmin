using System.Text.Json;
using System.Text.Json.Serialization;


namespace MalusAdmin.Common.Components.SystemTextJson;

/// <summary>
/// DateTime 格式转换
/// </summary>
public class DateTimeJsonConverter : System.Text.Json.Serialization.JsonConverter<DateTime>
{
    /// <summary>
    /// DateTime 格式
    /// </summary>
    public string Format { get; }

    /// <summary>
    /// DateTime 格式转换
    /// </summary>
    /// <param name="format">DateTime 格式</param>
    public DateTimeJsonConverter(string format = "yyyy-MM-dd HH:mm:ss")
    {
        Format = format;
    }

    /// <summary>
    /// 反序列化
    /// </summary>
    /// <param name="reader"></param>
    /// <param name="type"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public override DateTime Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
    {
        return reader.GetDateTime();
    }

    /// <summary>
    /// 序列化
    /// </summary>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    /// <param name="options"></param>
    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        //这里把时间格式做一个自顶一格式的转换就行
        writer.WriteStringValue(value.ToString(Format));
    }
 
}

 
/// <summary>
/// Enum 转换
/// </summary>
public class EnumJsonConverter : System.Text.Json.Serialization.JsonConverter<Enum>
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert.IsEnum;
    }

    public override Enum? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.TokenType switch
        {
            JsonTokenType.Number => reader.GetInt32().ToString(),
            JsonTokenType.String => reader.GetString(),
            _ => "0",
        };

        if (value == null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (Enum.TryParse(typeToConvert, value, out var result))
        {
            return result as Enum;
        }
        throw new InvalidOperationException("值不在枚举范围中");
    }

    public override void Write(Utf8JsonWriter writer, Enum value, JsonSerializerOptions options)
    {
        // 字符串
        //writer.WriteStringValue(value.ToString());
        //writer.WriteStringValue(Enum.GetName(value.GetType(), value));

        // 数字
        writer.WriteNumberValue(Convert.ToInt32(value));
    }
}