using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Course
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