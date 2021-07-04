using System;
using System.Collections.Generic;
using System.Text;

namespace ShopBridge.DTOs
{
    public class QueryParams
    {
        public string OrderBy { get; set; }
        public bool OrderByDesc { get; set; } = false;

        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public List<FilterBy> Filters { get; set; }
    }

    public class FilterBy
    {
        public string FilterProperty { get; set; }
        public string Keyword { get; set; }
    }
}
