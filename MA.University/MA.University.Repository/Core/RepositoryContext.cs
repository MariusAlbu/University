using MA.University.RepositoryAbstraction;
using MA.University.RepositoryAbstraction.Core;
using System;

namespace MA.University.Repository.Core
{
    public class RepositoryContext: IRepositoryContext
    {
        #region Members
        private static IRepositoryContext _instance;

        private IStudentRepository _studentRepository;
        private ICourseRepository _courseRepository;
        #endregion

        #region Constructor
        public RepositoryContext()
        {
            _instance = this;
        }
        #endregion

        #region Properties
        internal static IRepositoryContext Current
        {
            get
            {
                if (_instance == null)
                {
                    throw new Exception("No RepositoryContext instance available!");
                }
                return _instance;
            }
        }

        public IStudentRepository StudentRepository
        {
            get
            {
                if (_studentRepository == null)
                    _studentRepository = new StudentRepository();
                return _studentRepository;
                //return _container.GetRepository<IStudentRepository>();
            }
        }

        public ICourseRepository CourseRepository
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

                if (_instance != null)
                {
                    _instance = null;
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
