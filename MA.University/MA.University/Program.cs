using MA.University.Library;
using MA.University.Models;
using MA.University.Repository;
using MA.University.Repository.Core;
using System;
using System.Collections.Generic;

namespace MA.University
{
    class Program
    {
        static void Main(string[] args)
        {
            using (RepositoryContext repositoryContext = new RepositoryContext())
            {
                ShowStudents(repositoryContext);
                ShowCourses(repositoryContext);
            }

            //DelegateExample delegateExample = new DelegateExample();
            //delegateExample.DoStuff();

            Console.ReadKey();
        }

        private static void ShowStudents(RepositoryContext repositoryContext)
        {
            List<Student> students = repositoryContext.StudentRepository.ReadAll();

            Console.WriteLine("Students:");
            foreach (Student student in students)
            {
                Console.WriteLine("{0} - {1} {2}", student.ID, student.LastName, student.FirstName);
            }
        }

        private static void ShowCourses(RepositoryContext repositoryContext)
        {
            List<Course> courses = repositoryContext.CourseRepository.ReadAll();

            Console.WriteLine("Courses:");

            foreach (Course course in courses)
            {
                Console.WriteLine("{0} - {1}", course.ID, course.Name);
            }
        }
    }
}
