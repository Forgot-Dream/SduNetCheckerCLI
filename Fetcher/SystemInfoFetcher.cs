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
                    $"OS Type : {systemInfo.Platform.ToString()}",
                    $"OS Version : {systemInfo.Version.ToString()}"
                };
                return infoList;
            });

        }
    }
}
