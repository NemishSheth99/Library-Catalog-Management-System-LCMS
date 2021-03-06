using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LCMS.Web.Models
{
    public class ApplicationUserCreateVM
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

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please Enter Password")]
        [MinLength(8, ErrorMessage = "Password must contain atleast 8 characters"), MaxLength(32, ErrorMessage = "Password can not contain more than 32 characters")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one number and one special character")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Please Enter Confirm Password")]
        [MinLength(8, ErrorMessage = "Password must contain atleast 8 characters"), MaxLength(32, ErrorMessage = "Password can not contain more than 32 characters")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one number and one special character")]
        [Compare("Password",ErrorMessage ="Should be Same as Password")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Role")]
        [Required(ErrorMessage = "Please Select Role")]
        public int RoleId { get; set; }
    }
}