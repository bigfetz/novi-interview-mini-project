using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoviInterviewMiniProject.Models.Entities
{
    public class Member
    {
        public string UniqueID { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public MemberType MemberType { get; set; }

        public string CustomerType { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Mobile { get; set; }

        public string Website { get; set; }

        public string Image { get; set; }

        public Address BillingAddress { get; set; }

        public Address ShippingAddress { get; set; }

        public bool Active { get; set; }
    }
}