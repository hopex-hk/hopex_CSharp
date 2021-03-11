namespace Hopex.SDK.Core.Invoker.Models
{
    public static class InvokerOption
    {
        public static void SetConfig(string host, string apikey, string apiSecret,string userAgent)
        {
            HopexApiBase = host;
            ApiKey = apikey;
            ApiSecret = apiSecret;
            UserAgent = userAgent;
        }

        /// <summary>
        /// hopex api base
        /// </summary>
        public static string HopexApiBase { get; set; }

        public static string ApiKey { get; set; }

        public static string ApiSecret { get; set; }

        public static string UserAgent { get; set; }
    }
}
