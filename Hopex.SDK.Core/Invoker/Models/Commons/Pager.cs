namespace Hopex.SDK.Core.Invoker.Models.Commons
{
    public class Pager
    {
        public Pager() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page">page num</param>
        /// <param name="limit">page size</param>
        public Pager(int page, int limit)
        {
            Page = page;
            Limit = limit;
        }

        public int Page { get; set; }

        public int Limit { get; set; }

        public int Offset
        {
            get { return (Page - 1) * Limit; }
            set { Page = value / Limit + 1; }
        }
    }
}
