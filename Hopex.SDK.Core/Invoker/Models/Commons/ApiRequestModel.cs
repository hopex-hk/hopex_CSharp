namespace Hopex.SDK.Core.Invoker.Models.Commons
{
    /// <summary>
    /// api request model
    /// </summary>
    public class ApiRequestModel
    {
        public dynamic Param { get; set; }
    }

    /// <summary>
    /// api请求模型
    /// </summary>
    public class ApiRequestModel<T>
    {
        public T Param { get; set; }
    }
}
