using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Logging
{
    /// <summary>
    /// Allows make a systematic recording of events, observations, or measurements on base NLog Framework.
    /// </summary>
    public sealed class NLogger : ILogger
    {
        #region Private fields

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        #endregion


        #region Singleton

        private NLogger() { }

        /// <summary>
        /// Retuns instance of <see cref="NLogger"/> object.
        /// </summary>
        public static NLogger Instance { get; } = new NLogger();

        #endregion


        #region ILogger implementation

        /// <summary>
        /// Writes the diagnostic message at the Trace level.
        /// </summary>
        /// <param name="msg"> Log message. </param>
        public void Trace(string msg)
        {
            logger.Trace(msg);
        }

        /// <summary>
        /// Writes the diagnostic message at the Debug level.
        /// </summary>
        /// <param name="msg"> Log message. </param>
        public void Debug(string msg)
        {
            logger.Debug(msg);
        }

        /// <summary>
        /// Writes the diagnostic message at the Info level.
        /// </summary>
        /// <param name="msg"> Log message. </param>
        public void Info(string msg)
        {
            logger.Info(msg);
        }

        /// <summary>
        /// Writes the diagnostic message at the Warn level.
        /// </summary>
        /// <param name="msg"> Log message. </param>
        public void Warn(string msg)
        {
            logger.Warn(msg);
        }

        /// <summary>
        /// Writes the diagnostic message at the Error level.
        /// </summary>
        /// <param name="msg"> Log message. </param>
        public void Error(string msg)
        {
            logger.Error(msg);
        }

        /// <summary>
        /// Writes the diagnostic message at the Fatal level.
        /// </summary>
        /// <param name="msg"> Log message. </param>
        public void Fatal(string msg)
        {
            logger.Fatal(msg);
        }

        #endregion
    }
}
