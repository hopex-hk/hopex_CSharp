using System;

namespace Hopex.SDK.Core.Invoker.Exceptions
{
    public class InvokerFailException : Exception
    {
        public string ErrCode { get; set; }

        public InvokerFailException() { }

        public InvokerFailException(string message) : base(message) { }

        public InvokerFailException(string errCode, string message) : base(message)
        {
            ErrCode = errCode;
        }
    }
}
