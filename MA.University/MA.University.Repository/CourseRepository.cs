using MA.University.Models;
using MA.University.Repository.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MA.University.Repository
{
    public class CourseRepository : BaseRepository<Course>
    {
        #region Methods
        public List<Course> ReadAll()
        {
            //Get current StudentRepository instance
            return ReadAll("dbo.Courses_ReadAll");
        }

        protected override Course GetModelFromReader(SqlDataReader reader)
        {
            Course course = new Course();
            course.ID = reader.GetGuid(reader.GetOrdinal("CourseID"));
            course.Name = reader.GetString(reader.GetOrdinal("CourseName"));
            course.DepartmentID = reader.GetGuid(reader.GetOrdinal("DepartmentID"));
            course.Credits = reader.GetString(reader.GetOrdinal("Credits"));
            return course;
        }
        #endregion Methods
    }
}
