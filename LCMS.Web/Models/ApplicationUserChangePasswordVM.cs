using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LCMS.Web.Models
{
    public class ApplicationUserChangePasswordVM
    {
        public int Id { get; set; }

        [Display(Name = "Old Password")]
        [Required(ErrorMessage = "Please Enter Old Password")]
        [MinLength(8, ErrorMessage = "Password must contain atleast 8 characters"), MaxLength(32, ErrorMessage = "Password can not contain more than 32 characters")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one number and one special character")]
        public string OldPassword { get; set; }

        [Display(Name = "New Password")]
        [Required(ErrorMessage = "Please Enter New Password")]
        [MinLength(8, ErrorMessage = "Password must contain atleast 8 characters"), MaxLength(32, ErrorMessage = "Password can not contain more than 32 characters")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one number and one special character")]
        public string NewPassword { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Please Enter Password")]
        [MinLength(8, ErrorMessage = "Password must contain atleast 8 characters"), MaxLength(32, ErrorMessage = "Password can not contain more than 32 characters")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one number and one special character")]
        [Compare("NewPassword", ErrorMessage ="Should be same as Password")]
        public string ConfirmPassword { get; set; }
    }
}