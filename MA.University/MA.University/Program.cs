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
            StudentRepository studentRepository = new StudentRepository();

            Student student1 = new Student();
            student1.ID = Guid.NewGuid();
            student1.FirstName = "John";
            student1.LastName = "Smith";
            student1.Address = "";
            student1.City = "";
            student1.Country = "";
            student1.PhoneNumber = "";
            student1.EmailAddress = "";
            student1.BirthDay = new DateTime(1990, 12, 1);

            studentRepository.Insert(student1);

            List<Student> students = studentRepository.ReadAll();

            foreach (Student student in students)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }

            Console.ReadKey();
        }
    }
}
