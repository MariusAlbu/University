using System;
using System.Data.SqlClient;

namespace MA.University.Library
{
    public class DisposePatternExample
    {
        private SqlConnection _connection;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool dispose)
        {
            if (dispose)
            {
                if (_connection != null)
                {
                    _connection.Dispose();
                    _connection = null;
                }
            }
        }

        ~DisposePatternExample()
        {
            Dispose(false);
        }
    }
}
