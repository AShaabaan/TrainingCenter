﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CourseResult
    {
        public int Id { get; set; }
        public int Degree { get; set; }

        [ForeignKey("Course")]
        public int Crs_Id { get; set; }
        public virtual Course Course { get; set; }

        [ForeignKey("Trainee")]
        public int Trainee_Id { get; set; }
        public virtual Trainee Trainee { get; set; }

    }
}
