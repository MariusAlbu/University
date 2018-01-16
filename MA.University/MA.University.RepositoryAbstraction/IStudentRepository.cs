using MA.University.Models;
using System;
using System.Collections.Generic;

namespace MA.University.RepositoryAbstraction
{
    public interface IStudentRepository
    {
        List<Student> ReadAll();
        Student ReadById(Guid studentId);
        void Insert(Student student);
    }
}
