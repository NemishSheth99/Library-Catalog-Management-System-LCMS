using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LCMS.Web.Models
{
    public class BookPlaceCreateVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Place Code")]
        [Display(Name = "Place Code")]
        public string PlaceCode { get; set; }

        [Required(ErrorMessage = "Please Enter Material Type")]
        [Display(Name = "Material Type")]
        public string MaterialType { get; set; }
    }
}