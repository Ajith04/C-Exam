using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement
{
    internal class InsertCourse
    {
        public string Title { get; set; }
        public string Duration { get; set; }
        public decimal Price { get; set; }

        public InsertCourse(string title, string duration, decimal price)
        {
            Title = title;
            Duration = duration;
            Price = price;
        }
    }

}
