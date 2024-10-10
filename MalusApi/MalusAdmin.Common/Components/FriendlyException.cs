

// 自定义友好异常类
public class FriendlyException : Exception
{
    // 构造函数
    public FriendlyException(string message, int errorCode = 0)
        : base(message)
    {
        ErrorCode = errorCode;
    }

    // 错误代码
    public int ErrorCode { get; private set; } = 200;
}