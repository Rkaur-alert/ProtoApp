using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;
using ProtoApp.Models;
using Microsoft.Ajax.Utilities;

namespace ProtoApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        public bool isSubscribedToNewsletter { get; set; }
        
        public MembershipType MembershipType { get; set; }
        
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
        
        [Display(Name = "Date of birth")]
        public Nullable <DateTime> BirthDate { get; set; }
    }
}