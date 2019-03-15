using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly2.Models
{
    public class Min18YeasrsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

           
            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.Birthday == null)
                return new ValidationResult("Birthday is required if Membership Type is other than Pay as you go");

            var age = DateTime.Today.Year - customer.Birthday.Value.Year;

            return (age >= 18) ?
                ValidationResult.Success
                : new ValidationResult("Should be 18 years or above to be Member");
 
        }
    }
}