using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using PresentationLayer.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresentationLayer.ViewModels
{
    public class InstructorViewModel
    {
        

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        //public string Image { get; set; }
        [ValidateImage(new string[] { ".png", ".jpg", ".jpeg" })]
        public IFormFile Image { get; set; }


        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Salary { get; set; }

        [Required]
        [Display(Name = "Department")]
        public int Dept_ID { get; set; }

        public IEnumerable<SelectListItem>? Departments { get; set; }

        [Required]
        [Display(Name = "Course")]
        public int Crs_ID { get; set; }

        public IEnumerable<SelectListItem>? Courses { get; set; }
    }
}
