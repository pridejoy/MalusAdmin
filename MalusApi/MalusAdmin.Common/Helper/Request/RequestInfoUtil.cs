using IPTools.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Mapster;
using UAParser;
using System.Net;
using System.Net.Sockets;

namespace MalusAdmin.Request
{
    public static class RequestInfoUtil
    {
        /// <summary>
        /// 判断IP格式
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIP(string ip)
        {
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

        /// <summary>
        /// 获取IP
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public static string GetIp(HttpContext httpContext)
        {
            string ipAddress = httpContext.Connection.RemoteIpAddress.ToString();
            if (httpContext.Request.Headers.ContainsKey("X-Forwarded-For"))
            {
                string[] forwardedIps = httpContext.Request.Headers["X-Forwarded-For"].ToString().Split(',');
                ipAddress = forwardedIps.FirstOrDefault()?.Trim();
            }
            if (httpContext.Request.Headers.ContainsKey("X-Real-IP"))
            {
                string[] forwardedIps = httpContext.Request.Headers["X-Real-IP"].ToString().Split(',');
                string realIp = forwardedIps.FirstOrDefault()?.Trim();
                if (!string.IsNullOrEmpty(realIp) && realIp.Length > 7 && !realIp.StartsWith("127.0") && !realIp.StartsWith("192.168"))//代理、内网穿透等情况
                {
                    ipAddress = realIp;
                }
            }
            if (ipAddress.Contains("::1"))
                ipAddress = "127.0.0.1";
            return ipAddress.Replace("::ffff:", "");
        }

        /// <summary>
        /// 获取IP的信息
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static IpInfo GetIpInfo(string ip)
        {
            IPTools.Core.IpInfo ipInfo = IpTool.Search(ip);
            return ipInfo.Adapt<IpInfo>();
        }

        /// <summary>
        /// 获取UA标识
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public static string GetUserAgent(HttpContext httpContext)
        {
            return httpContext.Request.Headers["User-Agent"];
        }

        /// <summary>
        /// 获取UA的信息
        /// </summary>
        /// <param name="userAgent"></param>
        /// <returns></returns>
        public static UAInfo GetUserAgentInfo(string userAgent)
        {
            ClientInfo clientInfo = Parser.GetDefault().Parse(userAgent);
            UAInfo uaInfo = new UAInfo
            {
                Browser = clientInfo.UA.Family,
                OS = clientInfo.OS.Family,
                Device = clientInfo.Device.Family,
            };
            return uaInfo;
        }

    }

    /// <summary>
    /// Ip信息类 https://gitee.com/lsp5201314/IPTools
    /// </summary>
    public class IpInfo
    {
        /// <summary>
        /// IP地址
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// 国家(中国)
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// 国家-代码(CN)
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// 省(四川省)
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 省-代码(SC)
        /// </summary>
        public string ProvinceCode { get; set; }

        /// <summary>
        /// 城市(成都)
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 邮政编码
        /// </summary>
        public string PostCode { get; set; }

        /// <summary>
        /// 运营商
        /// </summary>
        public string NetworkOperator { get; set; }

        /// <summary>
        /// 维度
        /// </summary>
        public double? Latitude { get; set; } = 0.0;

        /// <summary>
        /// 经度
        /// </summary>
        public double? Longitude { get; set; } = 0.0;

        /// <summary>
        /// 计算的精确度
        /// </summary>
        public int? AccuracyRadius { get; set; }

        public override string ToString()
        {
            return string.Join("-", Country, Province, City);
        }
    }

    /// <summary>
    /// UserAgent信息类 https://github.com/ua-parser/uap-csharp
    /// </summary>
    public class UAInfo
    {
        public string Browser { get; set; }
        public string OS { get; set; }
        public string Device { get; set; }
    }
}
