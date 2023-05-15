using SduNetCheckerCLI.Util;

namespace SduNetCheckerCLI.Fetcher
{
    public class SystemProxyStatusFetcher
    {
        public static async Task<List<string>> FetchAsync()
        {
            return await Task.Run(() =>
            {
                List<string> data = new();
                try
                {
                    var proxyEnabled = RegUitl.RegReadValue(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings", "ProxyEnable", "-1");
                    var proxyEnabledString = proxyEnabled switch
                    {
                        "1" => "开启",
                        "0" => "关闭",
                        "-1" => "获取失败",
                        _ => "Unknown"
                    };
                    data.Add($"代理状态:{proxyEnabledString}");
                }
                catch (Exception exception)
                {
                    Logger.LogError(exception.Message);
                    return data;
                }
                return data;
            });
        }
    }
}
