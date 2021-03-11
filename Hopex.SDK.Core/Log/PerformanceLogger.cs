using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hopex.SDK.Core.Log
{
    public class PerformanceLogger
    {
        struct LogContent
        {
            public int Id;
            public string Endpoint;
            public string Url;
            public long TotalDuration;
            public long NetworkDuration;
            public long SDKDuration;
            public string Status;
        }

        private static readonly object _lock = new object();
        private static PerformanceLogger _pLogger;

        private bool _enable;
        private Stopwatch _stopwatch;
        private ILogger _logger;
        private int _logContentLineCount;

        private long _requestStart;
        private long _requestEnd;
        private string _requestStatus;
        private LogContent _logContent;

        private PerformanceLogger()
        {
            // Logger switch
            _enable = false;

            // Stopwatch
            _stopwatch = new Stopwatch();

            // Performance logger
            _logger = new ConsoleLogger();

            // Log content line count
            _logContentLineCount = 1;
        }

        /// <summary>
        /// Provide single instance
        /// </summary>
        /// <returns></returns>
        public static PerformanceLogger GetInstance()
        {
            if (_pLogger == null)
            {
                lock (_lock)
                {
                    if (_pLogger == null)
                    {
                        _pLogger = new PerformanceLogger();
                    }
                }
            }

            return _pLogger;
        }

        /// <summary>
        /// Set enable or disable the performance log
        /// </summary>
        /// <param name="enable"></param>
        public void Enable(bool enable)
        {
            _enable = enable;
        }

        /// <summary>
        /// Start timer
        /// </summary>
        public void Start([System.Runtime.CompilerServices.CallerMemberName] string methodName = "")
        {
            if (_enable)
            {
                _stopwatch.Restart();
                _logContent.Id = _logContentLineCount;
                _logContent.Endpoint = methodName;

            }
        }

        public void RquestStart(string method, string url, bool stripUrlParams = true)
        {
            if (_enable)
            {
                _stopwatch.Stop();
                _requestStart = _stopwatch.ElapsedMilliseconds;
                _stopwatch.Start();

                // Strip paramaters
                if (stripUrlParams)
                {
                    int i = url.IndexOf('?');
                    url = i > 0 ? url.Substring(0, i) : url;
                }

                _logContent.Url = $"{method} {url}";
            }
        }

        public void RequestEnd(string status)
        {
            if (_enable)
            {
                _stopwatch.Stop();
                _requestEnd = _stopwatch.ElapsedMilliseconds;
                _requestStatus = status;
                _stopwatch.Start();
            }
        }

        public void StopAndLog()
        {
            if (_enable)
            {
                _stopwatch.Stop();
                _logContent.TotalDuration = _stopwatch.ElapsedMilliseconds;
                _logContent.NetworkDuration = _requestEnd - _requestStart;
                _logContent.SDKDuration = _logContent.TotalDuration - _logContent.NetworkDuration;
                _logContent.Status = _requestStatus;

                // Log header if it is the first record
                if (_logContentLineCount == 1)
                {
                    _logger.Log(LogLevel.Trace, $"Index|Endpoint|URL|Total Duration(ms)|Request Duration(ms)|SDK Duration(ms)|Status");
                }

                _logger.Log(LogLevel.Trace, $"{_logContent.Id}|{_logContent.Endpoint}|{_logContent.Url}|{_logContent.TotalDuration}|{_logContent.NetworkDuration}|{_logContent.SDKDuration}|{_logContent.Status}");

                _logContentLineCount++;
            }
        }

    }
}
