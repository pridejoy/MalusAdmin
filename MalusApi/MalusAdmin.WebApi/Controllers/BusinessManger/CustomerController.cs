using MalusAdmin.Servers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MalusAdmin.WebApi.Controllers.BusinessManger;

/// <summary>
/// 用户服务
/// </summary> 
[ApiExplorerSettings(GroupName = "业务管理")]
public class CustomerController  : ApiControllerBase
{
    
    private readonly CustomerService _services;

    public CustomerController(CustomerService service)
    {
        _services = service;
    }
    
    
    /// <summary>
    /// 用户分页
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Permission("用户分页")]
    public async Task<dynamic> PageList([FromQuery]cuetomerPageIn input)
    {
        return await _services.PageList(input);
    }
  
}