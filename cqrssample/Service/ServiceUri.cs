using cqrssample.Core;
using Microsoft.AspNetCore.WebUtilities;
using System;

namespace cqrssample.Service
{
    public class ServiceUri : IServiceUri
    {
        private string baseUri;

        public ServiceUri(string baseUri)
        {
            this.baseUri = baseUri;
        }
        public Uri GetPageUri(PaginationFilter filter, string route)
        {
            var _enpointUri = new Uri(string.Concat(baseUri, route));
            var modifiedUri = QueryHelpers.AddQueryString(_enpointUri.ToString(), "pageNumber", filter.PageNumber.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "pageSize", filter.PageSize.ToString());
            return new Uri(modifiedUri);
        }
    }
}
