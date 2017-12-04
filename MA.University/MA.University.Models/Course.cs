using System;

namespace MA.University.Models
{
    public class Course
    {
        #region Properties
        public Guid ID { get; set; }
        public string Name { get; set; }
        public Guid DepartmentID { get; set; }
        public string Credits { get; set; }
        #endregion Properties
    }
}
