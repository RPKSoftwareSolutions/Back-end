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
            var obj = new
            {
                items = items,
                records = items.Count(),
                pages = Math.Ceiling((items.Count() + 0.0) / pageSize)
            };
            return obj;
        }

        public static object GetPageRecords(IEnumerable<object> items, int pageSize, int pageIndex, int count)
        {
            var obj = new
            {
                items = items,
                records = count, //items.Count(),
                pages = Math.Ceiling((count + 0.0) / pageSize)
            };
            return obj;
        }
    }
}
