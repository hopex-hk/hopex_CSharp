using System;

namespace Hopex.SDK.Core.Invoker.Utils
{
    public class DateTimeUtil
    {
        public static long GetTimestamps_seconds(DateTime dt)
        {
            return GetTimestamps(dt) / 1000;
        }

        public static long GetTimestamps(DateTime dt)
        {
            return (dt.ToUniversalTime().Ticks - 621355968000000000) / 10000;
        }
    }
}
