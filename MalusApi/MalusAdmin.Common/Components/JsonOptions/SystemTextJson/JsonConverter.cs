using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.SqlServer.Server;


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

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            if (DateTime.TryParse(reader.GetString(), out DateTime dateTime)) return dateTime;
        }
        return reader.GetDateTime();
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
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