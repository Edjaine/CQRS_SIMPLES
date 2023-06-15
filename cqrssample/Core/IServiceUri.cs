using System;

namespace cqrssample.Core
{
    public interface IServiceUri
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
