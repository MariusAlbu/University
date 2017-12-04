using MA.University.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MA.University.Repository
{
    public class CourseRepository
    {
        #region Methods
        public List<Course> ReadAll()
        {
            List<Course> courses = new List<Course>();
            string connectionString = "Server=MARIUS2;Database=UniversityDB;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Courses_ReadAll";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Course course = new Course();
                                course.ID = reader.GetGuid(reader.GetOrdinal("CourseID"));
                                course.Name = reader.GetString(reader.GetOrdinal("CourseName"));
                                course.DepartmentID = reader.GetGuid(reader.GetOrdinal("DepartmentID"));
                                course.Credits = reader.GetString(reader.GetOrdinal("Credits"));
                                courses.Add(course);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("There was an error: {0}", ex.ToString());
                }
            }

            return courses;
        }
        #endregion Methods
    }
}
