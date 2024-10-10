using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement
{
    internal class DigitalCourse : Course
    {

        public string CourseLink { get; set; }
        public string FileSize { get; set; }
        public DigitalCourse(int courseId, string title, string duration, decimal price, string courseLink, string fileSize) : base(courseId, title, duration, price)
        {

            CourseLink = courseLink;
            FileSize = fileSize;
        }

        

        public override string DisplayCourseInfo()
        {

            return base.DisplayCourseInfo() + $"Course Link: {CourseLink}\n File Size: {FileSize}";


        }
    }
}
