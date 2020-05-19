using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace CheckoutPromotion
{
    public class LogHelper : ILogger
    {       
        public LogHelper() { }
        public void LogDebug(string message,ILogger log)
        {
            log.LogDebug(message);
        }
        
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
        
        public bool IsEnabled(LogLevel logLevel)
        {
            return false;
        }
        
        
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {

        }
    }
}
