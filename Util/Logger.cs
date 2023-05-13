namespace SduNetCheckerCLI.Util
{
    public class Logger
    {
        public static void Log(object? text, bool enter = true)
        {
            Console.Write(text);
            if (enter) Console.WriteLine();
        }

        public static void LogError(object text)
        {
            Console.Write(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss.fff]") + " - ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(text);
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void LogColor(object title,object text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(title);
            Console.Write(" >>>");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(text);
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void LogWarn(object text)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(text);
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void LogDebug(string toFormat, params object[] args)
        {
            if (Config.DEBUG_LOG)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss.fff]") + " - ");
                if (args.Length > 0)
                    Console.Write(string.Format(toFormat, args).Trim());
                else
                    Console.Write(toFormat);
                Console.ResetColor();
                Console.WriteLine();
            }
        }
    }
}
