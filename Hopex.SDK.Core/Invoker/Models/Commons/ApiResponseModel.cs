namespace Hopex.SDK.Core.Invoker.Models.Commons
{
    public class ApiResponseModel
    {
        public ApiResponseModel()
        {
            Ret = 0;
        }

        /// <summary>
        /// success:0, fail:not 0
        /// </summary>
        public int Ret { get; set; }

        /// <summary>
        /// error code
        /// </summary>
        public string ErrCode { get; set; }

        /// <summary>
        /// error message
        /// </summary>
        public string ErrStr { get; set; }

        /// <summary>
        /// error message ("API rate limit exceeded || Hmac signature no match")
        /// </summary>
        public string Message { get; set; }
    }

    public class ApiResponseModel<T> : ApiResponseModel
    {
        public ApiResponseModel(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
    }

}
