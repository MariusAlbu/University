using System;

namespace MA.University.Models
{
    public class Student
    {
        #region Properties
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime BirthDay { get; set; }
        #endregion
    }
}
