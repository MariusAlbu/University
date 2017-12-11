using MA.University.Business.Core;
using MA.University.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.University.Business
{
    public class StudentBusiness
    {
        public List<Student> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.StudentRepository.ReadAll();
        }
    }
}
