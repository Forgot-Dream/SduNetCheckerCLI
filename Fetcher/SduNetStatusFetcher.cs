﻿using SduNetCheckerCLI.Util;

namespace SduNetCheckerCLI.Fetcher
{
    public class SduNetStatusFetcher
    {
        public static async Task<List<string>> FetchAsync()
        {
            return await Task.Run(async () =>
            {
                List<string> data = new();
                var httpClientHandler = new HttpClientHandler
                {
                    Proxy = null,
                    UseProxy = false
                };// 校园网判断请求禁用代理
                using HttpClient client = new(httpClientHandler);
                string text;
                try
                {
                    text = await client.GetStringAsync("http://101.76.193.1/cgi-bin/rad_user_info");
                    //text = await client.GetStringAsync("http://[2001:250:5800:11::1]/cgi-bin/rad_user_info"); //Ipv6认证地址未知
                }
                catch(Exception exception)
                {
                    Logger.LogError($"请求失败 : {exception.Message}");
                    data.Add("校园网状态 : 请求失败");
                    return data;
                }

                if (text.Contains("not_online_error"))
                {
                    data.Add("校园网状态 : 离线");
                    return data;
                }
                var infos = text.Split(",");
                data.Add("校园网状态 : 在线");
                data.Add($"校园网用户 : {infos[0]}");
                data.Add($"校园网IP地址 : {infos[8]}");
                return data;
            });
        }
    }
}
