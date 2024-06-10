using System.ComponentModel.DataAnnotations.Schema;


namespace Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }

        [ForeignKey("Department")]
        public int Dept_ID { get; set; }
        public virtual Department Department { get; set; }
        public virtual List<Attandance> Attandances { get; set; }
       public virtual List<CourseResult> Courses { get; set; }


    }
}
