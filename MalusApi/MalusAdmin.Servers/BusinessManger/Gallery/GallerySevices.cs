namespace MalusAdmin.Servers.Gallery;

public class GalleryService
{
    private readonly ISqlSugarClient _db;
    private readonly SqlSugarRepository<BsGallery> _repository; // 仓储
    private readonly ITokenService _TokenService;

    public GalleryService(SqlSugarRepository<BsGallery> repository, ITokenService tokenService)
    {
        _repository = repository;
        _TokenService = tokenService;
    }
    
    
    /// <summary>
    ///  必应壁纸列表分页
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PageList<BsGallery>> PageList(PageParamBase input)
    {
        var list = await _repository.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.KeyWord),
                u => u.Type.Contains(input.KeyWord.Trim()) )
            // .OrderByDescending(u=>u.StartDate)
            .ToPagedListAsync(input.PageNo, input.PageSize);
        return list.PagedResult();
    }
    
    
    
    /// <summary>
    /// 删除壁纸
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Delete(int id)
    {
        var entity = await _repository.FirstOrDefaultAsync(u => u.ImagesID == id);
        if (entity == null) throw ResultHelper.Exception207Bad("未找到当前角色"); 
        return await _repository.DeleteAsync(entity) > 0;
    }
}