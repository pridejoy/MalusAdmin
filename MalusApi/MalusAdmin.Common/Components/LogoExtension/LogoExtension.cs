using Microsoft.Extensions.DependencyInjection;

namespace MalusAdmin.Common.Components;

public static class LogoExtension
{
    public static void AddLogo(this IServiceCollection services)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        //var contentTpl = JnHelper.ReadTemplate("", "logo.txt");
        //var filePath = "wwwroot/logo.txt";
        // 使用StreamReader打开文件
        // using (var reader = new StreamReader(filePath))
        // {
        //     string line;
        //     // 逐行读取文件内容
        //     while ((line = reader.ReadLine()) != null) Console.WriteLine(line);
        // }
        
        string content = "  __  __         _                           _             _        \n |  \\/  |       | |    " +
                         "            /\\       | |           (_)       \n | \\  / |  __ _ | | _   _  ___    /  \\   " +
                         " __| | _ __ ___   _  _ __  \n | |\\/| | / _` || || | | |/ __|  / /\\ \\  / _` || '_ ` _ \\ | || '_ \\ \n | | " +
                         " | || (_| || || |_| |\\__ \\ / ____ \\| (_| || | | | | || || | | |\n |_|  |_| \\__,_||_| \\__,_||___//_/   " +
                         " \\_\\\\__,_||_| |_| |_||_||_| |_|\n                                                                     "; // 你的多行字符串

        // 使用 Split 方法按换行符分割字符串
        string[] lines = content.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

        // 遍历每一行并打印
        foreach (string line in lines)
        {
            if (!string.IsNullOrEmpty(line))
            {
                Console.WriteLine(line);
            }
        }
        //Console.WriteLine(content);
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("欢迎使用MalusAdmin 后台权限管理系统");
        Console.WriteLine("文档地址：https://www.dotnetshare.com");
        Console.WriteLine("在线体验：https://malus.dotnetshare.com");
        Console.WriteLine("微信号：Puredotnet<备注'项目'> ");
        Console.ForegroundColor = ConsoleColor.White;
    }
}