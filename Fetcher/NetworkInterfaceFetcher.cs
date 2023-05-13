using System.Net.NetworkInformation;

namespace SduNetCheckerCLI.Fetcher
{
    public class NetworkInterfaceFetcher
    {
        public static async Task<List<string>> FetchAsync()
        {
            return await Task.Run((() =>
            {
                NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
                List<string> returnData = new();
                foreach (var adapter in networkInterfaces)
                {

                    returnData.Add($"网卡: {adapter.Name} - {adapter.Description} - {adapter.NetworkInterfaceType} || {adapter.OperationalStatus}");
                    var ipProp = adapter.GetIPProperties();
                    returnData.Add($"IP地址: {string.Join(" || ", ipProp.UnicastAddresses.Select(x => x.Address.ToString()).ToList())}");
                    returnData.Add($"DNS服务器: {string.Join(" ", ipProp.DnsAddresses)}");
                    returnData.Add($"DHCP服务器: {string.Join(" ", ipProp.DhcpServerAddresses)}");
                    returnData.Add("=======");

                }
                return returnData;
            }));
        }
    }
}
