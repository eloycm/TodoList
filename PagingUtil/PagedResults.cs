using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagingUtil
{/// <summary>
 /// A class that handles pagination of an IQueryable
 /// </summary>
 /// <typeparam name="T"></typeparam>
    public class PagedResults<T>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="list">The full list of rows you would like to paginate</param>
        /// <param name="page">(optional) The current page number</param>
        /// <param name="pageSize">(optional) The size of the page</param>
        public PagedResults(IEnumerable<T> list, int? page = null, int? pageSize = null, int nRecords = 0)
        {
            _rows = list;
            _page = page;
            _pageSize = pageSize;
            records = nRecords.ToString();
            _nRecords = nRecords;
        }

        private IEnumerable<T> _rows;

        
        public IEnumerable<T> rows
        {
            get
            {
                return _rows;
            }
        }

        private int? _page;
        /// <summary>
        ///  The current page.
        /// </summary>
        public int page
        {
            get
            {
                if (!_page.HasValue)
                {
                    return 1;
                }
                else
                {
                    return _page.Value;
                }
            }
        }

        private int? _pageSize;
        
        /// <summary>
        /// The total number of rows in the original list of rows.
        /// </summary>
        public string records { get; set; }
        private int _nRecords;
        public int? total
        {
            get
            {
                return _nRecords / _pageSize +1;
            }
        }

    }
}
