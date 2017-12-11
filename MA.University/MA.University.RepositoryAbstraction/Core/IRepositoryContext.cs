using System;

namespace MA.University.RepositoryAbstraction.Core
{
    public interface IRepositoryContext: IDisposable
    {
        IStudentRepository StudentRepository { get; }
        ICourseRepository CourseRepository { get; }
    }
}
