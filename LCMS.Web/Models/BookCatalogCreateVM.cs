using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LCMS.Web.Models
{
    public class BookCatalogCreateVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [AllowHtml]
        [Display(Name = "Summary")]
        [Required(ErrorMessage = "Please Enter Summary")]        
        [MinLength(50, ErrorMessage = "Summary must contain atleast 50 characters")]
        public string Summary { get; set; }

        [Display(Name = "ISBN")]
        [Required(ErrorMessage = "Please Enter ISBN")]
        //[RegularExpression(@"/((978[\--– ])?[0-9][0-9\--– ]{10}[\--– ][0-9xX])|((978)?[0-9]{9}[0-9Xx])/", ErrorMessage = "Please Enter valid ISBN")]
        public string ISBN { get; set; }

        [Display(Name = "Publication Year")]
        [Required(ErrorMessage = "Please Enter Publication year")]
        public int PublicationYear { get; set; }

        [Display(Name = "Edition")]
        [Required(ErrorMessage = "Please Enter Edition")]
        public string Edition { get; set; }

        public List<string> Author { get; set; }

        [Display(Name = "Cover Image")]
        [Required(ErrorMessage = "Please Upload Cover Image")]
        public HttpPostedFileBase CoverImage { get; set; }

        [FileExtensions(Extensions = "jpg,jpeg,png,gif", ErrorMessage = "Only image file can be uploaded")]
        public string coverImagePath
        {
            get
            {
                if (CoverImage != null)
                    return CoverImage.FileName;
                else
                    return "";
            }
        }
    }
}