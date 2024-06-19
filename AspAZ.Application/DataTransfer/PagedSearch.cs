using System;
using System.Collections.Generic;
using System.Text;

namespace AspAZ.Application.DataTransfer
{
    public class PagedSearch
    {
        public int PerPage { get; set; } = 1;
        public int Page { get; set; } = 1;
    }
}
