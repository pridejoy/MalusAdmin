using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MalusAdmin.Common.Constant;
using Microsoft.AspNetCore.Authentication.OAuth;
using SqlSugar.Extensions;

namespace MalusAdmin.Common
{
    public class AppUser : IAppUser
    {
        private readonly HttpContext _httpContext;
        private readonly ICacheService _cacheService;
        public AppUser(IHttpContextAccessor httpContextAccessor, ICacheService cacheService)
        {
            _httpContext = httpContextAccessor?.HttpContext;
            _cacheService = cacheService;
        }

        #region 登录的账号信息

        /// <summary>
        /// 登录ID
        /// </summary>
        public TokenData Info
        {
            get
            {
                //if (IsAuthenticated)
                { 
                    var info = new TokenData();
                    switch (AuthenticateSettings.AuthenMethod)
                    {
                        case AuthenMethodStatus.Jwt:
                            info.UserId=  _httpContext?.User.Claims.FirstOrDefault(s => s.Type == AppUserConst.UserId)?.Value.ObjToInt()??-1;
                            info.UserAccount =  _httpContext?.User.Claims.FirstOrDefault(s => s.Type == AppUserConst.UserAccount)?.Value.ToString()??"";
                            info.IsSuperAdmin =  _httpContext?.User.Claims.FirstOrDefault(s => s.Type == AppUserConst.IsSuperAdmin)?.Value.ObjToBool()??false;
                          
                            break;

                        default:
                            var data= _cacheService.Get<Dictionary<string, string>>(CacheConstant.UserToken +HeaderToken);
                            info.UserId= data?.Where(s => s.Key == AppUserConst.UserId).FirstOrDefault().Value.ObjToInt()??-1;
                            info.UserAccount =  data?.Where(s => s.Key == AppUserConst.UserAccount).FirstOrDefault().Value.ToString()??"";
                            info.IsSuperAdmin = data?.Where(s => s.Key == AppUserConst.IsSuperAdmin).FirstOrDefault().Value.ObjToBool()??false;
                            break;
                    } 
                    
                    return info;
                }

                return default;
            }
        }

        #endregion

        #region jwt token

        /// <summary>
        /// jwt token
        /// </summary>
        /// <returns></returns>
        public string HeaderToken
        {
            get
            {
                if (_httpContext!=null)
                {
                    if (_httpContext.Request.Headers.ContainsKey("Authorization"))
                    {
                        return _httpContext?.Request.Headers["Authorization"].ToString()
                            .Replace("Bearer ", "").Trim();
                    }

                }
               

                return string.Empty;
            }
        }

        #endregion

        #region 是否已认证

        /// <summary>
        /// 是否已认证
        /// </summary>
        /// <returns></returns>
        public bool IsAuthenticated => _httpContext?.User.Identity?.IsAuthenticated ?? false;

        #endregion
    }
}
