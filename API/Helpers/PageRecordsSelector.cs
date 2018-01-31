using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public static class PageRecordsSelector
    {
        public static object GetPageRecords(IEnumerable<object> items, int pageSize, int pageIndex)
        {
            var subset = items;
            var obj = new
            {
                items = subset,
                records = items.Count(),
                pages = Math.Ceiling((items.Count() + 0.0) / pageSize)
            };
            return obj;
        }
    }
}
