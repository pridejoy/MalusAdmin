using Microsoft.AspNetCore.Authorization;

public class SimpleAuthorizationRequirement : IAuthorizationRequirement
{
    public SimpleAuthorizationRequirement(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}