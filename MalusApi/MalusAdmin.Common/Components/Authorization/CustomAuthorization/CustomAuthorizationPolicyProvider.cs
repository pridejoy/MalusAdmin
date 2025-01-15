using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

public class CustomAuthorizationPolicyProvider : DefaultAuthorizationPolicyProvider,IAuthorizationPolicyProvider
{
    public CustomAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options)
      : base(options)
    {
    }

    public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
    {
        // 返回默认策略，如果没有特定策略名称时使用
        var policy = new AuthorizationPolicyBuilder();
        policy.AddRequirements(new CustomAuthorizationRequirement());
        return Task.FromResult(policy.Build());
    }
 

    public async Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        var policy = await base.GetPolicyAsync(policyName);
        if (policy != null)
        {
            return policy;
        }

        if (!string.IsNullOrEmpty(policyName))
        {
            var policyBuilder = new AuthorizationPolicyBuilder(Array.Empty<string>());
            policyBuilder.AddRequirements(new CustomAuthorizationRequirement());
            return policyBuilder.Build();
        }

        return null;
    }
}