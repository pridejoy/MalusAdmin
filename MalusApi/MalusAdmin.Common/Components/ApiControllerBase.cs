using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MalusAdmin.Common
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Produces("application/json")] //返回数据的格式 直接约定为Json

    public class ApiControllerBase : ControllerBase
    {

        //public readonly ILogService _LogService;
        //public readonly ITokenService _TokenService;
        //public readonly ICacheService _CacheService;
        //public readonly HttpContext _HttpContext;
        //public ApiControllerBase(
        //    ITokenService tokenService, ICacheService cacheService, HttpContext httpContext)
        //{
        //    //_LogService = logService;
        //    _TokenService = tokenService;
        //    _CacheService = cacheService;
        //    _HttpContext = httpContext;
        //}
        /// <summary>
        /// 成功状态返回结果
        /// </summary>
        /// <param name="result">返回的数据</param>
        /// <returns></returns>
        protected ApiResult<T> SuccessResult<T>(T result)
        {
            return ApiResult<T>.SuccessResult(result);
        }
 
        /// <summary>
        /// 失败状态返回结果
        /// </summary>
        /// <param name="code">状态码</param>
        /// <param name="msg">失败信息</param>
        /// <returns></returns>
        protected ApiResult<T> FailResult<T>(string? msg = null)
        {
            return ApiResult<T>.FailResult(msg);
        }

        /// <summary>
        /// 异常状态返回结果
        /// </summary>
        /// <param name="code">状态码</param>
        /// <param name="msg">异常信息</param>
        /// <returns></returns>
        protected ApiResult<T> ErrorResult<T>(string? msg = null)
        {
            return ApiResult<T>.ErrorResult(msg);
        }

        /// <summary>
        /// 自定义状态返回结果
        /// </summary>
        /// <param name="status"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        protected ApiResult<T> Result<T>(ResultCode status, T result, string? msg = null)
        {
            return ApiResult<T>.Result(status, result, msg);
        }
    }
}
