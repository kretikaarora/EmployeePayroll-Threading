using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Threading_EmployeePayroll
{
    class NLog
    {
        /// <summary>
        /// Logger is a class which provides us with logging interface
        /// Log Manager manages the logs
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// log debug message
        /// </summary>
        /// <param name="message"></param>
        public void LogDebug(string message)
        {
            ///message is the information we want to print 
            Logger.Debug(message);
        }

        /// <summary>
        /// log error message
        /// </summary>
        /// <param name="message"></param>
        public void LogError(string message)
        {
            Logger.Error(message);
        }

        /// <summary>
        /// log info message
        /// </summary>
        /// <param name="message"></param>
        public void LogInfo(string message)
        {
            Logger.Info(message);
        }

        /// <summary>
        /// log warning message
        /// </summary>
        /// <param name="message"></param>
        public void LogWarn(string message)
        {
            Logger.Warn(message);
        }
    }
}
