using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement
{
    internal class CourseRepository
    {
        string connectionString = "Server=DESKTOP-GHFGR6A\\SQLEXPRESS;Database=CourseManagement;Trusted_Connection=true;TrustServerCertificate=true;";

        public void AddCourse(InsertCourse insertCourse)
        {
            string query = "insert into Courses values (@title, @duration, @price)";

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@title", insertCourse.Title);
                    command.Parameters.AddWithValue("@duration", insertCourse.Duration);
                    command.Parameters.AddWithValue("@price", insertCourse.Price);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Successfully added.");
                    }catch(Exception ex)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine("Error in adding course : " + ex.Message);
                    }
                }
            }
        }

        public List<Course> GetAll()
        {
            List<Course> courses = new List<Course>();

            string query = "select * from Courses";

            using(SqlConnection connection =new SqlConnection(connectionString))
            {
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Course getCourse = new Course(
                                    reader.GetInt32(0),
                                    reader.GetString(1),
                                    reader.GetString(2),
                                    reader.GetDecimal(3)

                                    );
                                courses.Add(getCourse);
                            }
                        }
                    }
                    catch (Exception ex) {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error in get courses : " + ex.Message);
                            }
                }
            }
            return courses;
        }

        public Course getCourseById(int id)
        {
            Course course = null;

            string query = "select * from Courses where CourseId=@courseId";

            using(SqlConnection connection = new SqlConnection(connectionString)) {
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@courseId", id);
                    try
                    {
                        connection.Open();
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                course = new Course(
                                    reader.GetInt32(0),
                                    reader.GetString(1),
                                    reader.GetString(2),
                                    reader.GetDecimal(3)
                                    );
                            }
                        }
                    }catch (Exception ex) {
                        Console.WriteLine();
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine("Error in retrieving course by id : " + ex.Message); }
                }
            }
            return course;
        }

        public void UpdateCourse(Course course)
        {
            string query = "update Courses set Title=@title, Duration=@duration, Price=@price where CourseId = @courseId";

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@courseId", course.CourseId);
                    command.Parameters.AddWithValue("@title", course.Title);
                    command.Parameters.AddWithValue("@duration", course.Duration);
                    command.Parameters.AddWithValue("@price", course.Price);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Successfully updated.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error in updating course : " + ex.Message);
                    }
                }
            }
        }

        public void DeleteCourse(int id)
        {
            string query = "delete Courses where CourseId = @courseId";

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@courseId", id);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Successfully deleted");
                    }catch (Exception ex)
                    {
                        Console.WriteLine("Error in deleting course : " + ex.Message);
                    }
                }
            }
        }

        public string CapitalizeTitle(string title)
        {
            var words = title.Split(' ');
            for (int i=0; i < words.Length; i++)
            {
                words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
            }
            return string.Join(" ", words);
        }
    }
}
