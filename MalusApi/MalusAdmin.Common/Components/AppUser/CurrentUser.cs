using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MalusAdmin.Common.Constant;
using Microsoft.AspNetCore.Authentication.OAuth;
using SqlSugar.Extensions;

namespace MalusAdmin.Common
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _accessor;
        //private readonly ICacheService _cacheService;
        public CurrentUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
            //_cacheService = cacheService;
        }

        public List<int> UserRolesId
        {
            get
            {
                var rolesValue = _accessor.HttpContext?.User.FindFirst(AppUserConst.UserRolesId)?.Value;
                if (string.IsNullOrEmpty(rolesValue))
                {
                    return new List<int>();
                }

                // 假设角色 ID 是用逗号分隔的字符串
                return rolesValue.Split(',').Select(int.Parse).ToList();
            }
        }

        int ICurrentUser.UserId => _accessor.HttpContext?.User.FindFirst(AppUserConst.UserId)?.Value.ObjToInt() ?? -1;

        string ICurrentUser.UserName => _accessor.HttpContext?.User.FindFirst(AppUserConst.UserAccount)?.Value??"";

        string ICurrentUser.UserAccount => _accessor.HttpContext?.User.FindFirst(AppUserConst.UserAccount)?.Value ?? "";

        bool ICurrentUser.IsSuperAdmin => _accessor.HttpContext?.User.FindFirst(AppUserConst.IsSuperAdmin)?.Value.ObjToBool() ?? false;



        #region 登录的账号信息

        /// <summary>
        /// 登录ID
        /// </summary>
        //public TokenData Info
        //{
        //    get
        //    {
        //        //if (IsAuthenticated)
        //        { 
        //            var info = new TokenData();
        //            switch (AuthenticationSettings.CurrentAuthenticationMethod)
        //            {
        //                case AuthenticationMethod.Jwt:
        //                    info.UserId=  _httpContext?.User.Claims.FirstOrDefault(s => s.Type == AppUserConst.UserId)?.Value.ObjToInt()??-1;
        //                    info.UserAccount =  _httpContext?.User.Claims.FirstOrDefault(s => s.Type == AppUserConst.UserAccount)?.Value.ToString()??"";
        //                    info.IsSuperAdmin =  _httpContext?.User.Claims.FirstOrDefault(s => s.Type == AppUserConst.IsSuperAdmin)?.Value.ObjToBool()??false;

        //                    break;

        //                default:
        //                    info.UserId = _httpContext?.User.Claims.FirstOrDefault(s => s.Type == AppUserConst.UserId)?.Value.ObjToInt() ?? -1;
        //                    info.UserAccount = _httpContext?.User.Claims.FirstOrDefault(s => s.Type == AppUserConst.UserAccount)?.Value.ToString() ?? "";
        //                    info.IsSuperAdmin = _httpContext?.User.Claims.FirstOrDefault(s => s.Type == AppUserConst.IsSuperAdmin)?.Value.ObjToBool() ?? false;

        //                    //var data = _cacheService.Get<U>(CacheConstant.UserToken +HeaderToken);
        //                    //info.UserId= data?.Where(s => s.Key == AppUserConst.UserId).FirstOrDefault().Value.ObjToInt()??-1;
        //                    //info.UserAccount =  data?.Where(s => s.Key == AppUserConst.UserAccount).FirstOrDefault().Value.ToString()??"";
        //                    //info.IsSuperAdmin = data?.Where(s => s.Key == AppUserConst.IsSuperAdmin).FirstOrDefault().Value.ObjToBool()??false;
        //                    break;
        //            } 

        //            return info;
        //        }

        //        return default;
        //    }
        //}

        #endregion




    }
}
