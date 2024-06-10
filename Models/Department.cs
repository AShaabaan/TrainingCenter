using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manager { get; set; }

        public virtual List<Instractor> Instractors { get; set; }
        public virtual List<Trainee> Trainees{ get; set; }
        public virtual List<Course> Courses { get; set; }


    }
}
