using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoviInterviewMiniProject.Models.Entities
{
    public class MemberType
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool ForCompanies { get; set; }
    }
}