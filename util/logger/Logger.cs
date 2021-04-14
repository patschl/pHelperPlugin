namespace Turbo.plugins.patrick.util.logger
{
    using Plugins;
    using Plugins.Patrick.util;

    public static class Logger
    {
        private const string LOG_FILE_PATH = @"phelper.log";
        
        private static ITextLogController LogController;
        
        public static LogLevel LogLevel = LogLevel.WARN;

        public static void Initialize(IController hud)
        {
            LogController = hud.TextLog;
        }

        private static void log(string text)
        {
            LogController?.Log(LOG_FILE_PATH, text);
        }

        public static void error(string text)
        {
            log("[ ERROR ] " + text);
        }
        
        public static void warn(string text)
        {
            if (LogLevel > LogLevel.WARN)
                return;
            
            log("[ WARN ] " + text);
        }
        
        public static void info(string text)
        {
            if (LogLevel > LogLevel.INFO)
                return;
            
            log("[ INFO ] " + text);
        }
        
        public static void debug(string text)
        {
            if (LogLevel > LogLevel.DEBUG)
                return;
            
            log("[ DEBUG ] " + text);
        }
    }
}