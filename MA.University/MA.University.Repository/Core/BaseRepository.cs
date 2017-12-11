using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace MA.University.Repository.Core
{
    public abstract class BaseRepository<TModel>
    {
        #region Members
        protected static string _connectionString = GetConnectionString();
        #endregion

        #region Methods
        private static string GetConnectionString()
        {
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["UniversityDB"];
            if (connectionStringSettings == null)
            {
                throw new ArgumentNullException("No connection string defined in the configuration file!");
            }

            return connectionStringSettings.ConnectionString;
        }

        public List<TModel> ReadAll(string storedProcedureName, IEnumerable<SqlParameter> parameters = default(IEnumerable<SqlParameter>))
        {
            List<TModel> result = new List<TModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = storedProcedureName;
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        if (parameters != null)
                        {
                            foreach (SqlParameter parameter in parameters)
                            {
                                command.Parameters.Add(parameter);
                            }
                        }

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(GetModelFromReader(reader));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("There was an error: {0}", ex.ToString());
                }
            }

            return result;
        }

        protected abstract TModel GetModelFromReader(SqlDataReader reader);
        #endregion
    }
}
