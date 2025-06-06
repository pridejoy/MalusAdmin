## DynamicWebApi使用教程


## 第一步：安装NuGet包

```bash
 Simple.DynamicWebApi
```

 

动态生成WebApi的组件，生成的API符合Restful风格

### 注册中间件
```csharp
services.AddDynamicApiController(); 

```

### 使用

创建一个类命名为 AppleService，实现 `IApplicationService` 接口 或者用特性 `DynamicApi`

```csharp
using Simple.DynamicWebApi.Abstractions;

public class AppleService : IDynamicWebApi
{

    [HttpGet("{id:int}")]
    public int Get(int id)
    {
        return id;
    }
}


[DynamicApi]
public class OrangeService 
{

    [HttpGet("{id:int}")]
    public int Get(int id)
    {
        return id;
    }
}

```