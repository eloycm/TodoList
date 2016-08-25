using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagingUtil.Extensions
{
    public static class PagingExtensions
    {
        public static PagedResults<T> ToPagedObject<T>(this IEnumerable<T> list, int page, int pagesize, int nRecords)
        {
            var rs = new PagedResults<T>(list, page, pagesize, nRecords);
            return rs;
        }
    }
}
