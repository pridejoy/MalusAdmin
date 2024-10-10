using Microsoft.Extensions.DependencyInjection;

namespace MalusAdmin.Common.Components;

public static class LogoExtension
{
    public static void AddLogo(this IServiceCollection services)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        //var contentTpl = JnHelper.ReadTemplate("", "logo.txt");
        var filePath = "wwwroot/logo.txt";
        // 使用StreamReader打开文件
        using (var reader = new StreamReader(filePath))
        {
            string line;
            // 逐行读取文件内容
            while ((line = reader.ReadLine()) != null) Console.WriteLine(line);
        }

        //Console.WriteLine(content);
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("文档地址：https://www.dotnetshare.com");
        Console.WriteLine("体验地址：https://malus.dotnetshare.com");
    }
}