using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using Microsoft.Extensions.DependencyModel;
using Newtonsoft.Json;
using SqlSugar;

namespace ConsoleApp1;

internal class Program
{
    private static void Main(string[] args)
    {
        //初始数据库 
        var ConnectionString = File.ReadAllText("D:\\testdb.txt");
        //var ConnectionString ="";

        var db = new SqlSugarClient(new ConnectionConfig
        {
            ConnectionString = ConnectionString,
            DbType = DbType.SqlServer,
            IsAutoCloseConnection = true
        });

        //建库：如果不存在创建数据库存在不会重复创建 createdb
        db.DbMaintenance.CreateDatabase(); // 注意 ：Oracle和个别国产库需不支持该方法，需要手动建库
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("建库完成");


        //获取所有的表类型
        //Type[] types = typeof(ConsoleApp1.Program).Assembly.GetTypes()
        //  .Where(it => it.FullName.Contains("MalusAdmin."))//命名空间过滤，当然你也可以写其他条件过滤
        //  .ToArray();

        // 根据名称获取程序集
        var assemblies = new List<Assembly>();
        var libs = DependencyContext.Default.CompileLibraries.Where(lib => !lib.Serviceable && lib.Type != "package");
        foreach (var lib in libs)
        {
            var assembly = AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(lib.Name));
            assemblies.Add(assembly);
        }

        // 获取程序集内名称以 MalusAdmin 结尾的 class
        var serviceTypes = assemblies.SelectMany(a => a.GetTypes())
            .Where(t => t.FullName.Contains("MalusAdmin"))
            .Distinct().ToArray();

        //根据types创建表 【创建多表】
        db.CodeFirst.SetStringDefaultLength(200).InitTables(serviceTypes); //根据types创建表
        Console.WriteLine("建表完成");

        //初始化数据
        // 假设你有一个字典来映射文件名到对应的类型
        var typeMappings = new Dictionary<string, Type>();

        foreach (var type in serviceTypes)
        {
            // 获取 SugarTable 特性
            var sugarTableAttribute = type.GetCustomAttribute<SqlSugar.SugarTable>();
            if (sugarTableAttribute!=null)
            {
                typeMappings.Add(sugarTableAttribute.TableName, type);
            } 
        }

        var path = Path.Combine(AppContext.BaseDirectory, "InitData");
        var dir = new DirectoryInfo(path);
        var files = dir.GetFiles("*.json");
        foreach (var file in files)
        {
            // 获取没有扩展名的文件名
            var name = Path.GetFileNameWithoutExtension(file.Name);
            Console.WriteLine("读取表数据:" + name);
            // 检查字典中是否有这个文件名的映射
            if (typeMappings.TryGetValue(name, out var YourType))
            {
                string json = File.ReadAllText(file.FullName, new UTF8Encoding(false));

                var typez = typeof(List<>).MakeGenericType(YourType);
                var list = JsonConvert.DeserializeObject(json, typez);

                if (list != null)
                {
                    // 执行数据库插入操作
                    db.StorageableByObject(list).ExecuteCommand();
                    Console.WriteLine("数据完成:" + name);
                }
            }
        }

        Console.WriteLine("插入更新表数据完成");
        //string s = File.ReadAllText(path+ "/bs_bingwallpaper.txt");
        //var table = JsonConvert.DeserializeObject<List<bs_bingwallpaper>>(s);
        //db.Insertable(table).ExecuteCommand();
    }
}