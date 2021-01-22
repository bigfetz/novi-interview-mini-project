using NoviInterviewMiniProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NoviInterviewMiniProject.Models.ViewModels
{
    public class MembersIndexViewModel
    {
        public TableModel TableModel { get; set; } 

        public IEnumerable<MemberItemViewModel> MemberRows { get; set; }
    }

    public class MemberItemViewModel
    {
        public string UniqueID { get; set; }

        public string Name { get; set; }

        public string MemberType { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Mobile { get; set; }

        public MemberItemViewModel(Member member)
        {
            UniqueID = member.UniqueID;
            Name = member.Name;
            MemberType = member.MemberType != null ? member.MemberType.Name + " (" + member.CustomerType + ")" : member.CustomerType;
            Email = member.Email;
            Phone = member.Phone;
            Mobile = member.Mobile;
        }
    }
}