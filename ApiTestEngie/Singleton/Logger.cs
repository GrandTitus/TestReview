using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Configuration;

namespace ApiTestEngie.Singleton
{
    public sealed class Logger
    {
        private static Logger _logger;
        private static readonly object _syncLock = new object();
        string fileName = WebConfigurationManager.AppSettings["logPath"];

        /// <summary>
        /// Singleton for the initialization of the log instance
        /// </summary>
        /// <returns>Object Logger</returns>
        public static Logger GetLogger()
        {
            if (_logger == null)
            {
                lock (_syncLock)
                {
                    if (_logger == null)
                    {
                        _logger = new Logger();
                    }
                }
            }
            return _logger;
        }
        /// <summary>
        /// Write the error message to the log file
        /// </summary>
        /// <param name="source">Stack </param>
        /// <param name="message">error message</param>
        public void WriteMessage(string request, string message)
        {
            if (!File.Exists(fileName))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(fileName))
                {
                    sw.WriteLine(string.Format("Error {0} - Request : {1} - Message : {2} ", DateTime.Now, request, message));
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(fileName))
                {
                    sw.WriteLine(string.Format("Error {0} - Request : {1} - Message : {2} ", DateTime.Now, request, message));
                }
            }

        }
    }
}