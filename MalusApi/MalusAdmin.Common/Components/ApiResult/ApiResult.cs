using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dm;
using Mapster.Utils;

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

    #region 接口返回的Json对象
    /// <summary>
    /// JsonR 接口返回的Json对象
    /// </summary>
    [Serializable]
    public class JsonR
    {
        public JsonR()
        {
            code = -1;
            message = string.Empty;
            body = null;
        }
        /// <summary>
        /// 返回码
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 返回说明
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 返回数据体 可为空
        /// </summary>
        public object body { get; set; }
    }
    #endregion

    #region JsonR 接口返回的Json对象
    [Serializable]
    public class JsonR<T>
    {
        public JsonR()
        {
            code = -1;
            message = string.Empty;
            body = default(T);
        }
        /// <summary>
        /// 返回码
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 返回说明
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 返回数据体 可为空
        /// </summary>
        public T body { get; set; }
    }
    #endregion
    public static class Tools
    {

        #region //根据枚举返回对应的状态码
        /// <summary>
        /// 根据枚举返回对应的状态码
        /// </summary>
        /// <param name="Code"></param>
        /// <param name="obj"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static JsonR JsonR(this Enum Code, object obj = null, string message = "")
        { 
            return new JsonR()
            {
                code = Code.GetHashCode(),
                message = string.IsNullOrEmpty(message) ? EnumHelper.GetDescription(Code) : message,
                body = obj
            };
        } 
        #endregion
    }



}
