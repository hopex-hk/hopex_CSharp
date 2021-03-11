using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hopex.SDK.Core.Invoker.Services;
using Hopex.SDK.Core.Models.Response.Account;

namespace Hopex.SDK.Core.Client
{
    public class AccountClient
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        public Task<GetUserInfoResponse> GetUserInfoAsync()
        {
            return HttpRequest.Get<GetUserInfoResponse>("/api/v1/userinfo", null, true);
        }
    }
}
