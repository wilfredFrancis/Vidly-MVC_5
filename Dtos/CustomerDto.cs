using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Vidly2.Models;

namespace Vidly2.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }
        /*
        [Display(Name = "Date of Birth")]
        [Min18YeasrsIfAMember]
        */
        public DateTime? Birthday { get; set; }
    }
}