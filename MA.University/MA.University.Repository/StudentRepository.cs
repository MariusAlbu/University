﻿using MA.University.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MA.University.Repository
{
    public class StudentRepository
    {
        #region Methods
        public List<Student> ReadAll()
        {
            List<Student> students = new List<Student>();
            string connectionString = "Server=MARIUS2;Database=UniversityDB;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Students_ReadAll";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Student student = new Student();
                                student.ID = reader.GetGuid(reader.GetOrdinal("StudentID"));
                                student.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                                student.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                                student.Address = reader.GetString(reader.GetOrdinal("Address"));
                                student.City = reader.GetString(reader.GetOrdinal("City"));
                                student.Country = reader.GetString(reader.GetOrdinal("Country"));
                                student.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
                                student.EmailAddress = reader.GetString(reader.GetOrdinal("EmailAddress"));
                                student.BirthDay = reader.GetDateTime(reader.GetOrdinal("BirthDay"));
                                students.Add(student);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("There was an error: {0}", ex.ToString());
                }
            }

            return students;
        }

        public void Insert(Student student)
        {
            string connectionString = "Server=MARIUS2;Database=UniversityDB;Trusted_Connection=True;";

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "dbo.Students_Insert";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@StudentID", student.ID));
                command.Parameters.Add(new SqlParameter("@FirstName", student.FirstName));
                command.Parameters.Add(new SqlParameter("@LastName", student.LastName));
                command.Parameters.Add(new SqlParameter("@Address", student.Address));
                command.Parameters.Add(new SqlParameter("@City", student.City));
                command.Parameters.Add(new SqlParameter("@Country", student.Country));
                command.Parameters.Add(new SqlParameter("@PhoneNumber", student.PhoneNumber));
                command.Parameters.Add(new SqlParameter("@EmailAddress", student.EmailAddress));
                command.Parameters.Add(new SqlParameter("@BirthDay", student.BirthDay));

                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("There was an SQL error: {0}", sqlEx.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error: {0}", ex.ToString());
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion
    }
}
