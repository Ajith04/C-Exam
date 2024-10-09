using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement
{
    internal class CourseManager
    {
        List<Course> courses = new List<Course>();

        public void CreateCourse(Course course)
        {
            courses.Add(course);
            Console.WriteLine("Course successfully added");
        }

        public void ReadCourses()
        {
            if(courses.Count == 0)
            {
                Console.WriteLine("No courses available");
            }
            else
            {
                foreach(var course in courses)
                {
                    Console.WriteLine(course);
                }
            }
        }

        public void UpdateCourse(int courseId, string title, string duration, decimal price)
        {
            var updateCourse = courses.SingleOrDefault(r => r.CourseId == courseId);

            if(updateCourse == null)
            {
                Console.WriteLine("Course not found");
            }
            else
            {
                courses.Remove(updateCourse);
                Course newCourse = new Course(courseId, title, duration, price);
                courses.Add(newCourse);
                Console.WriteLine("Successfully updated");
            }
        }

        public void DeleteCourse(int id)
        {
           var deleteCourse = courses.SingleOrDefault(r => r.CourseId == id);
            if(deleteCourse == null)
            {
                Console.WriteLine("Course not found");
            }
            else
            {
                courses.Remove(deleteCourse);
                Console.WriteLine("Successfully Deleted");
            }
        }

        public decimal validateCoursePrice()
        {
            while (true)
            {

                Console.Write("Enter Course Price : ");
                decimal price = decimal.Parse(Console.ReadLine());

                if (price > 0)
                {
                    return price;

                }
                else
                {

                    Console.WriteLine("Invalid price, press enter");
                    Console.ReadLine();


                }
            }
            
        }
    }
}
