using MA.University.Models;
using MA.University.Repository;
using System;
using System.Collections.Generic;

namespace MA.University
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowStudents();
            ShowCourses();

            Console.ReadKey();
        }

        private static void ShowStudents()
        {
            StudentRepository studentRepository = new StudentRepository();
            List<Student> students = studentRepository.ReadAll();

            Console.WriteLine("Students:");
            foreach (Student student in students)
            {
                Console.WriteLine("{0} - {1} {2}", student.ID, student.LastName, student.FirstName);
            }
        }

        private static void ShowCourses()
        {
            CourseRepository courseRepository = new CourseRepository();
            List<Course> courses = courseRepository.ReadAll();

            Console.WriteLine("Courses:");

            foreach (Course course in courses)
            {
                Console.WriteLine("{0} - {1}", course.ID, course.Name);
            }
        }
    }
}
