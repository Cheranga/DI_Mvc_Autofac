using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace DI_Mvc_Autofac.Infrastructure.Interfaces
{
    public interface ILogger
    {
        void LogWarning(string message);
        void LogInfo(string message);
        void LogError(string message);
    }

    public class DebugLogger : ILogger
    {
        public void LogWarning(string message)
        {
            Debug.WriteLine($"WARNING: {message}");
        }

        public void LogInfo(string message)
        {
            Debug.WriteLine($"INFO: {message}");
        }

        public void LogError(string message)
        {
            Debug.WriteLine($"ERROR: {message}");
        }
    }
}