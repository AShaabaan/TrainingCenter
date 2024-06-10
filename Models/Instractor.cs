using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Instractor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }

        [ForeignKey("Department")]
        public int Dept_ID { get; set; }
        public virtual Department Department { get; set; }

        [ForeignKey("Course")]
        public int Crs_ID { get;set; }
        public virtual Course Course { get; set; }

    }
}
