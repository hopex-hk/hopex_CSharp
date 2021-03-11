using System;
using System.Security.Cryptography;
using System.Text;

namespace Hopex.SDK.Core.Invoker.Utils
{
    public static class HashUtil
    {
        public static string HmacSha256(string content, string secret = "")
        {
            byte[] sha256Data = Encoding.UTF8.GetBytes(content);
            byte[] secretData = Encoding.UTF8.GetBytes(secret);

            using (var hmacsha256 = new HMACSHA256(secretData))
            {
                byte[] buffer = hmacsha256.ComputeHash(sha256Data);
                return Convert.ToBase64String(buffer);
            }
        }
    }


}
