using MA.University.Business.Core;
using MA.University.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace MA.University.API.Controllers
{
    [RoutePrefix("api/students")]
    public class StudentsController: ApiController
    {
        #region Methods
        //GET api/students
        [HttpGet]
        [Route("")]
        public IEnumerable<Student> ReadAll()
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.StudentBusiness.ReadAll();
            }
        }

        //GET api/students/{Guid}
        [HttpGet]
        [Route("{studentId:Guid}")]
        public Student ReadById(Guid studentId)
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.StudentBusiness.ReadById(studentId);
            }
        }

        //POST api/students
        [HttpPost]
        [Route("")]
        public void Insert([FromBody] Student student)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.StudentBusiness.Insert(student);
            }
        }
        #endregion
    }
}