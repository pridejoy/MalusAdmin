namespace MalusAdmin.Servers;

public class BingWallpaperService
{
    private readonly ISqlSugarClient _db;
    private readonly SqlSugarRepository<BsBingWallpaper> _repository; // 仓储
    private readonly ITokenService _TokenService;

    public BingWallpaperService(SqlSugarRepository<BsBingWallpaper> repository, ITokenService tokenService)
    {
        _repository = repository;
        _TokenService = tokenService;
    }
    
    
    /// <summary>
    ///  必应壁纸列表分页
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PageList<BsBingWallpaper>> PageList(PageParamBase input)
    {
        var list = await _repository.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.KeyWord),
                u => u.CopyRight.Contains(input.KeyWord.Trim()) )
            .OrderByDescending(u=>u.StartDate)
            .ToPagedListAsync(input.PageNo, input.PageSize);
        return list.PagedResult();
    }
}