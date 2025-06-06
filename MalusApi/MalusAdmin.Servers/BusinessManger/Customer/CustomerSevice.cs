using Microsoft.Extensions.DependencyInjection;

namespace MalusAdmin.Servers;

/// <summary>
/// 客户服务
/// </summary>
[ApiExplorerSettings(GroupName = nameof(ApiVersionGropInfo.BusinessManger))]
public class CustomerService: ApiControllerBase
{
    private readonly ISqlSugarClient _db;
    private readonly SqlSugarRepository<BsCustomer> _repository; // 仓储
    private readonly ITokenService _TokenService;

    public CustomerService(SqlSugarRepository<BsCustomer> repository, ITokenService tokenService)
    {
        _repository = repository;
        _TokenService = tokenService;
    }

    /// <summary>
    /// 客户列表分页
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<PageList<BsCustomer>> PageList([FromQuery] PageParamBase input)
    {
        var list = await _repository.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.KeyWord),
                u => u.NickName.Contains(input.KeyWord.Trim()) ) 
            .ToPagedListAsync(input.PageNo, input.PageSize);
        return list.PagedResult();
    }
 
}