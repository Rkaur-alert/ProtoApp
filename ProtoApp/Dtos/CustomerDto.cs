using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ProtoApp.Models;

namespace ProtoApp.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool isSubscribedToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; }

 //      [Min18YearsIfAMember]
        public Nullable<DateTime> BirthDate { get; set; }
    }
}