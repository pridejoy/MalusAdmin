using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

public class SimpleAuthorizationPolicyProvider : DefaultAuthorizationPolicyProvider, IAuthorizationPolicyProvider
{
    public SimpleAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options)
        : base(options)
    { }

    /// <summary>
    /// 异步获取默认授权策略。
    /// </summary>
    /// <returns>默认授权策略。</returns>
    public new Task<AuthorizationPolicy> GetDefaultPolicyAsync()
    {
        var policyBuilder = new AuthorizationPolicyBuilder(Array.Empty<string>());
        policyBuilder.AddRequirements(new SimpleAuthorizationRequirement(""));
        var policy = policyBuilder.Build();
        return Task.FromResult(policy);
    }

    /// <summary>
    /// 根据策略名称异步获取授权策略。
    /// </summary>
    /// <param name="policyName">策略名称。</param>
    /// <returns>授权策略，如果未找到则返回 null。</returns>
    public override async Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        var policy = await base.GetPolicyAsync(policyName);
        if (policy != null)
        {
            return policy;
        }

        if (!string.IsNullOrEmpty(policyName))
        {
            var policyBuilder = new AuthorizationPolicyBuilder(Array.Empty<string>());
            policyBuilder.AddRequirements(new SimpleAuthorizationRequirement(policyName));
            return policyBuilder.Build();
        }

        return null;
    }
}
