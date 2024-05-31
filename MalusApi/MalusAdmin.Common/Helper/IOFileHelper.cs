namespace MalusAdmin.Common.Helper;

public static class IOFileHelper
{
    //相对路径
    //await WriteAsync("file.txt", "Hello World", true, "UTF-8");
    //await WriteAsync("subfolder/file.txt", "Hello World", true, "UTF-8");
    /// <summary>
    ///     创建文件或者附加内容
    /// </summary>
    /// <param name="Data">要写入的文本</param>
    /// <param name="Encode">编码方式</param>
    /// <param name="filePath">文件路径(支持相对路径或绝对路径)</param>
    /// <param name="IsAppend">附加还是全新写入</param>
    public static async Task<bool> Write(string Data, string filePath = "", bool IsAppend = true,
        string Encode = "UTF-8")
    {
        filePath = filePath.Contains("txt")
            ? filePath
            : "logs/" + filePath + DateTime.Now.ToString("yyyyMMdd") + ".log";
        Encode = string.IsNullOrEmpty(Encode) ? "UTF-8" : Encode;
        Data = DateTime.Now + "  :" + Data + "\n";
        try
        {
            //获取文件对象
            var file = new FileInfo(filePath);
            //判断文件夹是否创建
            if (!file.Directory.Exists) file.Directory.Create();
            //判断文件是否存在
            //或者判断文件属性是否只读,是只读的话将只读属性去掉
            if (!file.Exists)
                using (file.Create())
                {
                }
            else if (file.Attributes.ToString().IndexOf("ReadOnly") != -1) file.IsReadOnly = false;

            //将内容覆盖或者追加到文件的最后
            using (var writer = new StreamWriter(file.FullName, IsAppend, Encoding.GetEncoding(Encode)))
            {
                writer.Write(Data);
                writer.Flush();
            }

            return true;
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            return false;
        }
    }
}