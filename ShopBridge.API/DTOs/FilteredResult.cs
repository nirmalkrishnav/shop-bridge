using System;
using System.Collections.Generic;
using System.Text;

namespace ShopBridge.DTOs
{
    public class FilteredResult
    {
        public List<Inventory> Result { get; set; }
        public int Page { get; set; }
        public int Total { get; set; }
        public QueryParams QueryParams { get; set; }
    }
}
