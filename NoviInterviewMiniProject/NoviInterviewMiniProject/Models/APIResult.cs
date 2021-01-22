using System.Collections.Generic;

namespace NoviInterviewMiniProject.Models
{
    public class APIResult<T>
    {
        public int TotalCount { get; set; }

        public IEnumerable<T> Results { get; set; }
    }
}