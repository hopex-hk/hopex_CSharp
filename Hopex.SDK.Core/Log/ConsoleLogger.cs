using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hopex.SDK.Core.Log
{
    public class ConsoleLogger : ILogger
    {
        public void Log(LogLevel level, string message)
        {
            string dateTime = DateTime.UtcNow.ToString("s");
            Console.WriteLine($"{dateTime} | {level} | {message}");
        }
    }
}
