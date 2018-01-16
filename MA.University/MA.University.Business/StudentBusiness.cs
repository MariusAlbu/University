using MA.University.Business.Core;
using MA.University.Models;
using System;
using System.Collections.Generic;

namespace MA.University.Business
{
    public class StudentBusiness
    {
        public List<Student> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.StudentRepository.ReadAll();
        }

        public Student ReadById(Guid studentId)
        {
            return BusinessContext.Current.RepositoryContext.StudentRepository.ReadById(studentId);
        }

        public void Insert(Student student)
        {
            BusinessContext.Current.RepositoryContext.StudentRepository.Insert(student);
        }
    }
}
