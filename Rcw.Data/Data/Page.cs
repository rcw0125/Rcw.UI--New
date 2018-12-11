using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rcw.Data
{
    public class Page
    {
        public int limit { set; get; }
        public int offset { set; get; }
        public int count { get; set; }
    }
}
