using System;

namespace Hopex.SDK.Core.Models.Response.Home
{
    public class GetIndexNotifyResponse
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 跳转链接
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// 详细时间
        /// </summary>
        public DateTime LastModifiedTime { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// 时间戳（秒）
        /// </summary>
        public long Timestamp { get; set; }
    }
}
