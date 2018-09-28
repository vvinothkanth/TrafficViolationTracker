//-----------------------------------------------
//  Problem Title : Trafic violence
//  Author        : Vinoth Kanth V
//  Date          : 19 / 9 / 2018
//-----------------------------------------------

/// <summary>
///  The Traffic Violation Tracking System NameSpace
/// </summary>
namespace TrafficViolationTrackingSystem
{
    using System;
    using System.IO;
    using System.Reflection;

    /// <summary>
    /// The Logger Class 
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// File path
        /// </summary>
        private static string filePath = string.Empty;

        /// <summary>
        /// to Load a log file
        /// </summary>
        /// <param name="logMessage"></param>
        public static void WriteLine(string logMessage)
        {
            filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            try
            {
                using (StreamWriter streamWriter = File.AppendText(filePath + "\\" + "log.txt"))
                {
                    Log(logMessage, streamWriter);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        /// To write the log informations
        /// </summary>
        /// <param name="logMessage"></param>
        /// <param name="txtWriter"></param>
        private static void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("  :{0}", logMessage);
                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
