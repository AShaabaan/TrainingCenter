using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Attandance
    {
        public int Id { get; set; }
        public int NumberOfAbs { get; set; }
        public int NumberOfAttend { get; set; }

        [ForeignKey("Trainee")]
        public int Traine_Id { get ; set; }
        public virtual Trainee Trainee { get; set; }

    }
}
