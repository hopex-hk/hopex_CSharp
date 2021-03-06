using System.Collections.Generic;

namespace Hopex.SDK.Core.Invoker.Models.Commons
{
    public class ListResultViewModel<T>
    {
        public ListResultViewModel()
        {
            Result = new T[0];
        }

        public ListResultViewModel(Pagination<T> pagination)
        {
            TotalCount = pagination.TotalCount;
            Page = pagination.Page;
            PageSize = pagination.Limit;

            Result = pagination;
        }

        public int TotalCount { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public IEnumerable<T> Result { get; set; }
    }
}
