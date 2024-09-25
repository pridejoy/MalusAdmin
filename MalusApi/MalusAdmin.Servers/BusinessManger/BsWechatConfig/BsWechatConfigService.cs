using MalusAdmin.Repository.Entity;
using MalusAdmin.Servers;
using Mapster;

namespace MalusAdmin.Server
{
    public class BsWechatConfigService
    {
        private readonly ISqlSugarClient _db;
        private readonly SqlSugarRepository<BsWechatConfig> _rep; // 仓储
        private readonly ITokenService _TokenService;

        public BsWechatConfigService(SqlSugarRepository<BsWechatConfig> rep, ITokenService tokenService)
        {
            _rep = rep;
            _TokenService = tokenService;
        }

        /// <summary>
        /// 配置分页
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PageList<BsWechatConfig>> PageList(PageParamBase input)
        {
            var dictTypes = await _rep.AsQueryable()
                .WhereIF(!string.IsNullOrWhiteSpace(input.KeyWord),
                    u => u.ConfigKey.Contains(input.KeyWord.Trim()) || u.ConfigValue.Contains(input.KeyWord.Trim()))
                 .Where(u => u.IsDeleted == false)
                 .ToPagedListAsync(input.PageNo, input.PageSize);
            return dictTypes.PagedResult();
        }

        /// <summary>
        /// 添加配置
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Add(WechatConfigAddandUpIn input)
        {
            var isExist = await _rep.Where(x => x.ConfigKey == input.ConfigKey).AnyAsync();
            if (isExist) throw new Exception("已存在当前配置");
            var entity = input.Adapt<BsWechatConfig>();
            entity.IsDeleted=false;
            return await _rep.InsertReturnIdentityAsync(entity) > 0;
        }

        /// <summary>
        /// 删除配置
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<bool> Delete(int id)
        {
            var entity = await _rep.FirstOrDefaultAsync(u => u.ConfigID == id);
            if (entity == null) throw new Exception("为找到当前配置");
            return await _rep.DeleteAsync(u => u.ConfigID == id) > 0;
        }

        /// <summary>
        /// 更新配置
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<bool> Update(WechatConfigAddandUpIn input)
        {
            var entity = await _rep.FirstOrDefaultAsync(u => u.ConfigID == input.ConfigID);
            if (entity == null) throw new Exception("未找到当前配置");
            var sysRole = input.Adapt<BsWechatConfig>();
            return await _rep.AsUpdateable(sysRole).IgnoreColumns(true).ExecuteCommandAsync() > 0;
        }
    }
}