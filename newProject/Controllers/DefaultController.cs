using newProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace newProject.Controllers
{
    public class EmployeesController : ApiController
    {
        //[HttpGet]
        public HttpResponseMessage LoadAllEmployees()
        {
            using (WEBAPI_DBEntities dbContext=new WEBAPI_DBEntities())
            {
                var empl = dbContext.Employees.ToList();
                return Request.CreateResponse(HttpStatusCode.OK, empl);
            }
        }

        public HttpResponseMessage Get(string gender = "All")
        {
            using(WEBAPI_DBEntities dbContext=new WEBAPI_DBEntities())
            {
                switch (gender.ToLower())
                {
                    case "all":
                        return Request.CreateResponse(HttpStatusCode.OK, dbContext.Employees.ToList());
                    case "male":
                        return Request.CreateResponse
                            (HttpStatusCode.OK, dbContext.Employees.Where(emp => emp.Gender.ToLower().Equals("male")).ToList());

                    case "female":
                        return Request.CreateResponse(HttpStatusCode.OK, dbContext.Employees.Where(emp => emp.Gender.ToLower().Equals("female")).ToList());
                    default:
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Value for the gender should be male, female, all " + gender + " is invalid gender");
                }
            }
        }

        /*
         * We can also use ([FromBody]int id, [FromUri]Employee employee) in the parameter of the action
         */
        public HttpResponseMessage Put(int id,Employee emp)
        {
            try
            {
                using(WEBAPI_DBEntities dbContext=new WEBAPI_DBEntities())
                {
                    var entity = dbContext.Employees.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id " + id + " not found");
                    }
                    else
                    {
                        entity.FirstName = emp.FirstName;
                        entity.Gender = emp.Gender;
                        entity.LastName = emp.LastName;
                        entity.Salary = emp.Salary;
                        dbContext.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        #region Normal Get Method
        //public IEnumerable<Employee> Get()
        //{
        //    using(WEBAPI_DBEntities dbContext =new WEBAPI_DBEntities())
        //    {
        //        return dbContext.Employees.ToList();
        //    }
        //}
        //public Employee Get(int id)
        //{
        //    using(WEBAPI_DBEntities dbContext=new WEBAPI_DBEntities())
        //    {
        //        return dbContext.Employees.FirstOrDefault(emp => emp.ID == id);
        //    }
        //}
        #endregion
    }
}
