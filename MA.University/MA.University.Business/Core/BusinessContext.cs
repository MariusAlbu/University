using MA.University.RepositoryAbstraction.Core;
using MA.University.RepositoryFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.University.Business.Core
{
    public class BusinessContext: IDisposable
    {
        #region Members
        private static BusinessContext _instance;

        private IRepositoryContext _repositoryContext;

        private StudentBusiness _studentBusiness;
        private CourseBusiness _courseBusiness;
        #endregion

        #region Constructor
        public BusinessContext()
        {
            _instance = this;
            _repositoryContext = Getter.GetRepository();
        }
        #endregion

        #region Properties
        internal static BusinessContext Current
        {
            get
            {
                if (_instance == null)
                {
                    throw new Exception("No BusinessContext instance available!");
                }
                return _instance;
            }
        }

        public StudentBusiness StudentBusiness
        {
            get
            {
                if (_studentBusiness == null)
                    _studentBusiness = new StudentBusiness();
                return _studentBusiness;
            }
        }

        public CourseBusiness CourseBusiness
        {
            get
            {
                if (_courseBusiness == null)
                    _courseBusiness = new CourseBusiness();
                return _courseBusiness;
            }
        }

        internal IRepositoryContext RepositoryContext
        {
            get { return _repositoryContext; }
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
                if (_courseBusiness != null)
                {
                    //_connection.Dispose();
                    _courseBusiness = null;
                }

                if (_studentBusiness != null)
                {
                    //_connection.Dispose();
                    _studentBusiness = null;
                }

                if (_repositoryContext != null)
                {
                    _repositoryContext.Dispose();
                    _repositoryContext = null;
                }

                if (_instance != null)
                {
                    _instance = null;
                }
            }
        }

        ~BusinessContext()
        {
            Dispose(false);
        }
        #endregion
    }
}
