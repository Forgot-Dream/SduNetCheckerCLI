// See https://aka.ms/new-console-template for more information

using SduNetCheckerCLI;
using SduNetCheckerCLI.Fetcher;
using SduNetCheckerCLI.Util;

Logger.LogColor(SduNetChecker.VERSION, " / ___|  __| |_   _| \\ | | ___| |_ / ___| |__   ___  ___| | _____ _ __ \n \\___ \\ / _` | | | |  \\| |/ _ \\ __| |   | '_ \\ / _ \\/ __| |/ / _ \\ '__|\n  ___) | (_| | |_| | |\\  |  __/ |_| |___| | | |  __/ (__|   <  __/ |   \n |____/ \\__,_|\\__,_|_| \\_|\\___|\\__|\\____|_| |_|\\___|\\___|_|\\_\\___|_|   \n                                                                       ");
Logger.Log("本项目开源于https://github.com/Forgot-Dream/SduNetCheckerCLI,欢迎Issue,PR.");

Logger.LogColor("系统信息", string.Join("\n", SystemInfoFetcher.FetchAsync().Result));
Logger.LogColor("网卡信息", string.Join("\n", NetworkInterfaceFetcher.FetchAsync().Result));
Logger.LogColor("校园网状态", string.Join("\n", SduNetStatusFetcher.FetchAsync().Result));

if (Environment.OSVersion.Platform is PlatformID.Win32NT or PlatformID.Win32S or PlatformID.Win32Windows)
    Logger.LogColor("代理检测(Win)", string.Join("\n", SystemProxyStatusFetcher.FetchAsync().Result));


Console.WriteLine("Press any key to exit.");
Console.ReadKey();
