using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement
{
    internal class OnPremiseCourse : Course
    {

        public string Schedule { get; set; }
        public string ClassroomCapacity { get; set; }
        public OnPremiseCourse(int courseId, string title, string duration, decimal price, string schedule, string classroomCapacity) : base(courseId, title, duration, price)
        {
            Schedule = schedule;
            ClassroomCapacity = classroomCapacity;
        }

        public override string DisplayCourseInfo()
        {
            return base.DisplayCourseInfo() + $"Schedule: {Schedule}\n Classroom Capacity:{ClassroomCapacity}";
           

        }


    }
}
