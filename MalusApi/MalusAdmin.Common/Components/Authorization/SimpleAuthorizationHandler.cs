using Microsoft.AspNetCore.Authorization;

public class SimpleAuthorizationHandler : AuthorizationHandler<SimpleAuthorizationRequirement>
{
    private readonly IPermissionChecker _checker;

    public SimpleAuthorizationHandler(IPermissionChecker checker)
    {
        _checker = checker;
    }

    /// <summary>
    ///     处理满足简单授权需求的授权逻辑。
    /// </summary>
    /// <param name="context">授权上下文。</param>
    /// <param name="requirement">授权需求。</param>
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
        SimpleAuthorizationRequirement requirement)
    {
        if (await _checker.IsGrantedAsync(context.User, requirement.Name)) context.Succeed(requirement);
    }
}