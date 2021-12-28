using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.GenericHelper
{
    internal class Log4NetHelper
    {
        private static ILog _logger;
        private static ConsoleAppender consoleAppender;
        private static FileAppender fileAppender;
        private static RollingFileAppender rollingFileappender;
        private static string layout = "[%level] [%class]-%message%newline";


        public static string Layout
        {
            set { layout = value; }
        }
        private static PatternLayout GetPatternLayout()
        {
            var patternLayout = new PatternLayout()
            {
                ConversionPattern = layout
            };
            patternLayout.ActivateOptions();
            return patternLayout;
        }
        private static ConsoleAppender GetConsoleAppender()
        {
            var consoleAppender = new ConsoleAppender()
            {
                Name = "ConsoleAppender",
                Layout = GetPatternLayout(),
                Threshold = Level.All

            };
            consoleAppender.ActivateOptions();
            return consoleAppender;
        }

        private static FileAppender GetFileAppender()
        {
            var fileAppender = new FileAppender()
            {
                Name = "FileAppender",
                Layout = GetPatternLayout(),
                Threshold = Level.All,
                AppendToFile = false,
                File = "FileLogger.log"
            };
            fileAppender.ActivateOptions();
            return fileAppender;
        }
        private static RollingFileAppender GetRollingFileAppender()
        {
            var rollingAppender = new RollingFileAppender()
            {
                Name = "Rolling File Appender",
                AppendToFile = false,
                File = "RollingFile.log",
                Layout = GetPatternLayout(),
                Threshold = Level.All,
                MaximumFileSize = "1MB",
                MaxSizeRollBackups = 15 //count =15
            };
            rollingAppender.ActivateOptions();
            return rollingAppender;
        }

        public static ILog GetLog(Type type)
        {
            if (consoleAppender == null)
                consoleAppender = GetConsoleAppender();
            if (fileAppender == null)
                fileAppender = GetFileAppender();
            if (rollingFileappender == null)
                rollingFileappender = GetRollingFileAppender();
            if (_logger != null)
                return _logger;
            BasicConfigurator.Configure(consoleAppender, fileAppender, rollingFileappender);
            _logger = LogManager.GetLogger(type);
            return _logger;
        }
    }
}
