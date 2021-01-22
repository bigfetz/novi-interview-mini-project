using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoviInterviewMiniProject.Models
{
    public class TableModel
    {
        public string Search { get; set; }

        public string SortOn { get; set; }

        public bool IsAsc { get; set; }
    }
}