using System.ComponentModel;

namespace MalusAdmin.Common;

public enum ApiCode
{
    [Description("成功")]
    成功 = 200,

    //Exception207Bad
    [Description("自定义错误信息")]
    Exception207Bad = 207,
    自定义错误信息 = 207,

    [Description("错误的请求")]
    错误的请求 = 400,

    [Description("没有登录状态")]
    没有登录状态 = 401,

    [Description("缺少权限")]
    缺少权限 = 403,

    [Description("找不到资源")]
    找不到资源 = 404,

    [Description("存在冲突")]
    存在冲突 = 409,

    [Description("服务器错误")]
    服务器错误 = 500
}