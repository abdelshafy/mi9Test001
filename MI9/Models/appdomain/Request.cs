using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Dynamic;

namespace MI9.Models.appdomain
{
    public class Request
    {
        public IEnumerable<dynamic> payload { set; get; }
        public int skip { set; get; }
        public int take { set; get; }
        public int totalRecords { set; get; }
    }
}