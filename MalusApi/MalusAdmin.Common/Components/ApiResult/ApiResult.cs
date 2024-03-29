using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalusAdmin.Common
{
    /// <summary>
    /// 统一返回结果处理
    /// </summary>
    public class ApiResult<T>
    {
        /// <summary>
        /// 状态结果
        /// </summary>
        public ResultCode Status { get; set; } = ResultCode.Success;


        private string? _msg;

        /// <summary>
        /// 消息描述
        /// </summary>
        public string? Message
        {
            get
            {
                return !string.IsNullOrEmpty(_msg) ? _msg : EnumHelper.GetDescription(Status);
            }
            set
            {
                _msg = value;
            }
        }

        /// <summary>
        /// 返回结果
        /// </summary>
        public T Data { get; set; }


        /// <summary>
        /// 成功状态返回结果
        /// </summary>
        /// <param name="result">返回的数据</param>
        /// <returns></returns>
        public static ApiResult<T> SuccessResult(T data)
        {
            return new ApiResult<T> { Status = ResultCode.Success, Data = data };
        }

        /// <summary>
        /// 失败状态返回结果
        /// </summary>
        /// <param name="code">状态码</param>
        /// <param name="msg">失败信息</param>
        /// <returns></returns>
        public static ApiResult<T> FailResult(string? msg = null)
        {
            return new ApiResult<T> { Status = ResultCode.Fail, Message = msg };
        }

        /// <summary>
        /// 异常状态返回结果
        /// </summary>
        /// <param name="code">状态码</param>
        /// <param name="msg">异常信息</param>
        /// <returns></returns>
        public static ApiResult<T> ErrorResult(string? msg = null)
        {
            return new ApiResult<T> { Status = ResultCode.Error, Message = msg };
        }

        /// <summary>
        /// 自定义状态返回结果
        /// </summary>
        /// <param name="status"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static ApiResult<T> Result(ResultCode status, T data, string? msg = null)
        {
            return new ApiResult<T> { Status = status, Data = data, Message = msg };
        }
    }

    /// <summary>
    /// 定义具体的返回状态码
    /// </summary>
    public enum ResultCode
    {
        [Description("请求成功")]
        Success = 1,
        [Description("请求失败")]
        Fail = 0,
        [Description("请求异常")]
        Error = -1
    }
}
