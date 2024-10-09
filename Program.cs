using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Course course = new Course(1,"HTML","03 Months",3000);
            var singleCourse = course.ToString();
            Console.WriteLine(singleCourse);
            

            Course myCourse = new Course(2, "CSS", "02 Months", 2000);

            CourseManager courseManager = new CourseManager();
            courseManager.CreateCourse(myCourse);
            
            courseManager.UpdateCourse(2, "C#", "01 Month", 5000);
            
            courseManager.DeleteCourse(2);
            courseManager.ReadCourses();

            




            bool repeat = false;

            while(!repeat)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Course Management System");
                Console.WriteLine("...........................");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1. Add a Course");
                Console.WriteLine("2. view all Courses");
                Console.WriteLine("3. Update a Course");
                Console.WriteLine("4. Delete a Course");
                Console.WriteLine("5. Exit");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Choose an Option : ");
                Console.ForegroundColor = ConsoleColor.White;
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddCourse();
                        break;
                    case "2":
                        getCourse();
                        break;
                    case "3":
                        editCourse();
                        break;
                    case "4":
                        DeleteCourse();
                        break;
                    case "5": repeat=true;
                        break;
                    default: Console.WriteLine("Invalid Option"); Console.ReadLine();
                        break;

                }
                
            }
            
        }

        public static void AddCourse()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Add a Course");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter Course Title : ");
            string title = Console.ReadLine();
            Console.Write("Enter Course Duration : ");
            string duration = Console.ReadLine();

            
            
            CourseManager courseManager = new CourseManager();
            decimal validatedPrice = courseManager.validateCoursePrice();

            CourseRepository courseRepository = new CourseRepository();
            string capitalTitle = courseRepository.CapitalizeTitle(title);

            InsertCourse insertCourse = new InsertCourse(capitalTitle, duration, validatedPrice);

            
            courseRepository.AddCourse(insertCourse);

            



            Console.ReadKey();


        }

        public static void getCourse()
        {
            Console.Clear();
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.WriteLine("All Courses");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            CourseRepository getCourseRepo = new CourseRepository();
            var allCourses = getCourseRepo.GetAll();

            foreach ( var course in allCourses )
            {
                Console.WriteLine(course);
            }
            

            Console.ReadKey();
        }

        public static void editCourse()
        {
            Console.Clear();
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.WriteLine("Update Course");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.Write("Enter Course Id to update : ");
            int courseId = int.Parse(Console.ReadLine());
            Console.Write("Enter Course title : ");
            string title = Console.ReadLine();
            Console.Write("Enter Duration : ");
            string duration = Console.ReadLine();
            

            CourseManager courseManager = new CourseManager();
            decimal validatedPrice = courseManager.validateCoursePrice();

            Course course = new Course(courseId, title, duration, validatedPrice);

            CourseRepository updateCourseRepo = new CourseRepository();
            updateCourseRepo.UpdateCourse(course);

            Console.ReadKey();



        }

        public static void DeleteCourse()
        {
            Console.Clear();
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.WriteLine("Delete a Course");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.Write("Enter a Course Id : ");
            int id = int.Parse(Console.ReadLine());

            CourseRepository updateCourseRepo = new CourseRepository();
            updateCourseRepo.DeleteCourse(id);

            Console.ReadKey();

        }


        
       
    }
}
