## DynamicWebApi使用教程


感谢[Mikoto](https://gitee.com/misaka11639)提供的代码

动态生成WebApi的组件，生成的API符合Restful风格

### 注册中间件
```csharp
services.AddDynamicApiController(); 

```

### 使用

创建一个类命名为 AppleService，实现 `IApplicationService` 接口 或者 `IDynamicWebApi`

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

```