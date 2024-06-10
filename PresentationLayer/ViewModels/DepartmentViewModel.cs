using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.ViewModels
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        [Required, MaxLength(50), MinLength(2),]
        public string Name { get; set; }
        [Required, MaxLength(50), MinLength(3), DataType(DataType.Text)]
        public string Manager { get; set; }
    }
}
