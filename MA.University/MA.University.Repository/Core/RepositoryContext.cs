using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.University.Repository.Core
{
    public class RepositoryContext: IDisposable
    {
        #region Members
        private StudentRepository _studentRepository;
        private CourseRepository _courseRepository;
        #endregion

        #region Properties
        public StudentRepository StudentRepository
        {
            get
            {
                if (_studentRepository == null)
                    _studentRepository = new StudentRepository();
                return _studentRepository;
            }
        }

        public CourseRepository CourseRepository
        {
            get
            {
                if (_courseRepository == null)
                    _courseRepository = new CourseRepository();
                return _courseRepository;
            }
        }
        #endregion

        #region IDisposable Implementation
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool dispose)
        {
            if (dispose)
            {
                if (_courseRepository != null)
                {
                    //_connection.Dispose();
                    _courseRepository = null;
                }

                if (_studentRepository != null)
                {
                    //_connection.Dispose();
                    _studentRepository = null;
                }
            }
        }

        ~RepositoryContext()
        {
            Dispose(false);
        }
        #endregion
    }
}
