using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Vidly2.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Subscription")]
        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        [Required(ErrorMessage = "Membership is required")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YeasrsIfAMember]
        public DateTime? Birthday { get; set; }

    }
}