// See https://aka.ms/new-console-template for more information

using SduNetCheckerCLI.Fetcher;
using SduNetCheckerCLI.Util;

Logger.LogColor(string.Join("\n",SystemInfoFetcher.FetchAsync().Result));
Logger.LogColor(string.Join("\n", NetworkInterfaceFetcher.FetchAsync().Result));
Logger.LogColor(string.Join("\n", SduNetStatusFetcher.FetchAsync().Result));

