using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LCMS.Web.Models
{
    public class ApplicationUserEditVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Please Enter Email Address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address Format")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Please Enter Phone Number")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Invalid Phone Number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Role")]
        [Required(ErrorMessage = "Please Select Role")]
        public int RoleId { get; set; }
    }
}