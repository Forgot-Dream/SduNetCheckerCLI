using Microsoft.Win32;

namespace SduNetCheckerCLI.Util
{
    public static class RegUitl
    {
        public static string? RegReadValue(string path, string name, string def)
        {
            RegistryKey? regKey = null;
            try
            {
                regKey = Registry.CurrentUser.OpenSubKey(path, false);
                string? value = regKey?.GetValue(name).ToString();
                if (IsNullOrEmpty(value))
                {
                    return def;
                }
                else
                {
                    return value;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
            }
            finally
            {
                regKey?.Close();
            }
            return def;
        }


        public static bool IsNullOrEmpty(string? text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return true;
            }
            return text == "null";
        }
    }
}
