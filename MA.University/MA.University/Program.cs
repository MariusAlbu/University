using MA.University.Business.Core;
using MA.University.Models;
using System;
using System.Collections.Generic;

namespace MA.University
{
    class Program
    {
        static void Main(string[] args)
        {
            using (BusinessContext businessContext = new BusinessContext())
            {
                ShowStudents(businessContext);
                ShowCourses(businessContext);
            }


            //DelegateExample delegateExample = new DelegateExample();
            //delegateExample.DoStuff();

            Console.ReadKey();
        }

        private static void ShowStudents(BusinessContext businessContext)
        {
            List<Student> students = businessContext.StudentBusiness.ReadAll();

            Console.WriteLine("Students:");
            foreach (Student student in students)
            {
                Console.WriteLine("{0} - {1} {2}", student.ID, student.LastName, student.FirstName);
            }
        }

        private static void ShowCourses(BusinessContext businessContext)
        {
            List<Course> courses = businessContext.CourseBusiness.ReadAll();

            Console.WriteLine("Courses:");

            foreach (Course course in courses)
            {
                Console.WriteLine("{0} - {1}", course.ID, course.Name);
            }
        }
    }
}
