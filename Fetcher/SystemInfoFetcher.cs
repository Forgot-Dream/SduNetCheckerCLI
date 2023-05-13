namespace SduNetCheckerCLI.Fetcher
{
    public class SystemInfoFetcher
    {
        public static async Task<List<string>> FetchAsync()
        {
            return await Task.Run(() =>
            {
                var systemInfo = Environment.OSVersion;
                List<string> infoList = new()
                {
                    $"系统类型 : {systemInfo.Platform}",
                    $"系统版本 : {systemInfo.Version}"
                };
                return infoList;
            });

        }
    }
}
