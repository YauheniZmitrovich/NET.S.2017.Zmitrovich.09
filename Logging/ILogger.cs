namespace Logging
{
    /// <summary>
    /// Allows make a systematic recording of events, observations, or measurements.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Writes the diagnostic message at the Trace level.
        /// </summary>
        /// <param name="msg"> Log message. </param>
        void Trace(string msg);

        /// <summary>
        /// Writes the diagnostic message at the Debug level.
        /// </summary>
        /// <param name="msg"> Log message. </param>
        void Debug(string msg);

        /// <summary>
        /// Writes the diagnostic message at the Info level.
        /// </summary>
        /// <param name="msg"> Log message. </param>
        void Info(string msg);

        /// <summary>
        /// Writes the diagnostic message at the Warn level.
        /// </summary>
        /// <param name="msg"> Log message. </param>
        void Warn(string msg);

        /// <summary>
        /// Writes the diagnostic message at the Error level.
        /// </summary>
        /// <param name="msg"> Log message. </param>
        void Error(string msg);

        /// <summary>
        /// Writes the diagnostic message at the Fatal level.
        /// </summary>
        /// <param name="msg"> Log message. </param>
        void Fatal(string msg);
    }
}