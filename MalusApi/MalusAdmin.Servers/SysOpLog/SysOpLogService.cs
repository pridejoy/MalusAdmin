using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MalusAdmin.Common;
using MalusAdmin.Entity;
using MalusAdmin.Servers.SysOpLog.Dto;
using MalusAdmin.Servers.SysUser.Dto;
using Models;
using SqlSugar;

namespace MalusAdmin.Servers
{
    public class SysOpLogService
    {
        private readonly ISqlSugarClient _db;
        private readonly SqlSugarRepository<TSysLogVis> _rep;  // 仓储

        public SysOpLogService(SqlSugarRepository<TSysLogVis> rep)
        {
            _rep = rep; 
        }


        /// <summary>
        /// 日志列表分页
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PageList<TSysLogVis>> PageList(SysLogPageIn input)
        {
            var dictTypes = await _rep.Context.Queryable<TSysLogVis>()
                 .SplitTable(tabs => tabs.Take(1))
                 .WhereIF(!string.IsNullOrWhiteSpace(input.KeyWord), u => u.Name.Contains(input.KeyWord.Trim()) )
                 .OrderByDescending(u => u.OpTime)
                 //.WhereIF(input.Status != null, u => u.Status == input.Status)
                 //.Select<UserPageOut>()
                 .ToPagedListAsync(input.PageNo, input.PageSize);
            return dictTypes.PagedResult();
        }
    }
}
