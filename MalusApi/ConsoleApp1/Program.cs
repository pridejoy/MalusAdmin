using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SqlSugar;
using Wallpaper.Net.Repository.Model;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //初始数据库 
            var ConnectionString = File.ReadAllText("D:\\MalusAdmindb.txt");
            //var ConnectionString ="";

            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = ConnectionString,
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true
            });

            //建库：如果不存在创建数据库存在不会重复创建 createdb
            db.DbMaintenance.CreateDatabase(); // 注意 ：Oracle和个别国产库需不支持该方法，需要手动建库
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("建库完成");


            //获取所有的表类型
            Type[] types = typeof(ConsoleApp1.Program).Assembly.GetTypes()
              .Where(it => it.FullName.Contains("Wallpaper."))//命名空间过滤，当然你也可以写其他条件过滤
              .ToArray();
            //根据types创建表 【创建多表】
            db.CodeFirst.SetStringDefaultLength(200).InitTables(types);//根据types创建表
            Console.WriteLine("建表完成");

            //初始化数据
            // 假设你有一个字典来映射文件名到对应的类型
            var typeMappings = new Dictionary<string, Type>() ;

            foreach (var item in types)
            {
                typeMappings.Add(item.Name, item);
            }

            string path = Path.Combine(AppContext.BaseDirectory, "InitData");
            var dir = new DirectoryInfo(path);
            var files = dir.GetFiles("*.txt");
            foreach (var file in files)
            {
                // 获取没有扩展名的文件名
                var name = Path.GetFileNameWithoutExtension(file.Name);
                Console.WriteLine("读取表数据:"+name);
                // 检查字典中是否有这个文件名的映射
                if (typeMappings.TryGetValue(name, out Type YourType))
                {
                    using var reader = file.OpenText();
                    string jsonArray = reader.ReadToEnd();

                    Type typez = typeof(List<>).MakeGenericType(YourType);
                    var list = JsonConvert.DeserializeObject(jsonArray, typez);

                    if (list != null)
                    {
                        // 执行数据库插入操作
                        db.StorageableByObject(list).ExecuteCommand();
                        Console.WriteLine("数据完成:"+ name);
                    }
                } 
            }
            Console.WriteLine("插入更新表数据完成");
            //string s = File.ReadAllText(path+ "/bs_bingwallpaper.txt");
            //var table = JsonConvert.DeserializeObject<List<bs_bingwallpaper>>(s);
            //db.Insertable(table).ExecuteCommand();
        }
    }
}
