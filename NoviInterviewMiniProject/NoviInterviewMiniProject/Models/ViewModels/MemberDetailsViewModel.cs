using NoviInterviewMiniProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NoviInterviewMiniProject.Models.ViewModels
{
    public class MemberDetailsViewModel
    {
        public string Name { get; set; }

        public string MemberType { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Mobile { get; set; }

        public string Website { get; set; }

        public string Image { get; set; }

        [Display(Name = "Billing Address")]
        public string BillingAddress { get; set; }

        [Display(Name= "Shipping Address")]
        public string ShippingAddress { get; set; }

        public MemberDetailsViewModel(Member member)
        {
            Name = member.Name;
            MemberType = member.MemberType != null ? member.MemberType.Name + " (" + member.CustomerType + ")" : member.CustomerType;
            Email = member.Email;
            Phone = member.Phone;
            Mobile = member.Mobile;
            Website = member.Website;
            Image = member.Image;

            if(member.BillingAddress != null)
            {
                BillingAddress = member.BillingAddress.Address1
                    + (!string.IsNullOrEmpty(member.BillingAddress.Address2) ? " " + member.BillingAddress.Address2 : "")
                    + (!string.IsNullOrEmpty(member.BillingAddress.City) ? " " + member.BillingAddress.City : "")
                    + (!string.IsNullOrEmpty(member.BillingAddress.StateProvince) ? " " + member.BillingAddress.StateProvince : "")
                    + (!string.IsNullOrEmpty(member.BillingAddress.ZipCode) ? " " + member.BillingAddress.ZipCode : "")
                    + (!string.IsNullOrEmpty(member.BillingAddress.Country) ? " " + member.BillingAddress.Country : "");
            }

            if (member.ShippingAddress != null)
            {
                ShippingAddress = member.ShippingAddress.Address1
                    + (!string.IsNullOrEmpty(member.ShippingAddress.Address2) ? " " + member.ShippingAddress.Address2 : "")
                    + (!string.IsNullOrEmpty(member.ShippingAddress.City) ? " " + member.ShippingAddress.City : "")
                    + (!string.IsNullOrEmpty(member.ShippingAddress.StateProvince) ? " " + member.ShippingAddress.StateProvince : "")
                    + (!string.IsNullOrEmpty(member.ShippingAddress.ZipCode) ? " " + member.ShippingAddress.ZipCode : "")
                    + (!string.IsNullOrEmpty(member.ShippingAddress.Country) ? " " + member.ShippingAddress.Country : "");
            }
        }
    }
}