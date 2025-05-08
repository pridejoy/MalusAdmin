using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// 自动注入特性
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
public class AutoInjectAttribute : Attribute
{
    public ServiceLifetime Lifetime { get; }

    public AutoInjectAttribute(ServiceLifetime lifetime = ServiceLifetime.Scoped)
    {
        Lifetime = lifetime;
    }
}