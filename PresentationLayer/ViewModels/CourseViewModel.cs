using Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresentationLayer.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Degree { get; set; }
        public int MinDegree { get; set; }

        [ForeignKey("Department")]
        public int Dept_ID { get; set; }
        public virtual Department Department { get; set; }

        List<CourseResult> CoursesResult { get; set; }
    }
}
