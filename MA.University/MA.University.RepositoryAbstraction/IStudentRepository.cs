using MA.University.Models;
using System.Collections.Generic;

namespace MA.University.RepositoryAbstraction
{
    public interface IStudentRepository
    {
        List<Student> ReadAll();
        void Insert(Student student);
    }
}
