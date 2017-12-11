using MA.University.Models;
using System.Collections.Generic;

namespace MA.University.RepositoryAbstraction
{
    public interface ICourseRepository
    {
        List<Course> ReadAll();
    }
}
