using Models;

namespace PresentationLayer.Models
{
    public class TraineeViewModel
    {
        public string TraineeName { get; set; }
        public string Deparment { get; set; }
        public List<CourseResult> Courses { get; set; } = new List<CourseResult>();
        public string Color { get; set; }
        public string State { get; set; }


        

    }
}
