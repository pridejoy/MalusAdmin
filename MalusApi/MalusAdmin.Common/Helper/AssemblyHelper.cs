using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyModel;

public static class AssemblyHelper
{
    /// <summary>
    /// 获取项目程序集（排除系统程序集、NuGet包）
    /// </summary>
    /// <returns></returns>
    public static IList<Assembly> GetAssemblies()
    {
        // 参考：https://www.cnblogs.com/yanglang/p/6866165.html

        List<Assembly> result = new List<Assembly>();
        var libs = DependencyContext.Default.CompileLibraries.Where(lib => !lib.Serviceable && lib.Type != "package");
        foreach (var lib in libs)
        {
            var assembly = AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(lib.Name));
            result.Add(assembly);
        }
        return result;
    }

    /// <summary>
    /// 将程序集加载到 AssemblyLoadContext.Default 中，并且获取这个程序集。
    /// （这个方法，主要是为了解决程序集没有被加载的情况）.
    /// Load the assemblies into AssemblyLoadContext.Default, and get it.
    /// </summary>
    /// <param name="dllNames">程序集的名称，如：Test 或 Test.dll </param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static IEnumerable<Assembly> GetAssemblies(params string[] dllNames)
    {
        var basePath = AppContext.BaseDirectory;

        var assemblies = new List<Assembly>();
        var dllFileFullNames = new List<string>();

        foreach (var dllName in dllNames)
        {
            var dllFileName = dllName.ToLower().EndsWith(".dll") ? dllName : dllName + ".dll";
            var dllFileFullName = Path.Combine(basePath, dllFileName);

            if (!File.Exists(dllFileFullName))
            {
                throw new Exception($"{dllFileName}不存在！");
            }

            dllFileFullNames.Add(dllFileFullName);
        }

        foreach (var dllFileFullName in dllFileFullNames)
        {
            var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(dllFileFullName);
            assemblies.Add(assembly);
        }

        return assemblies;
    }

    /// <summary>
    /// 将程序集加载到 AssemblyLoadContext.Default 中，并且获取这个程序集。
    /// （这个方法，主要是为了解决程序集没有被加载的情况）.
    /// Load the assemblies into AssemblyLoadContext.Default, and get it.
    /// </summary>
    /// <param name="dllNames">程序集的名称，如：Test 或 Test.dll </param>
    /// <returns></returns>
    public static IEnumerable<Assembly> GetAssemblies(IEnumerable<string> dllNames)
        => GetAssemblies(dllNames.ToArray());
}