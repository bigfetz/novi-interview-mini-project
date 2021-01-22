using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoviInterviewMiniProject.Models
{
    public class APIResult<T>
    {
        public int TotalCount { get; set; }

        public IEnumerable<T> Results { get; set; }
    }
}