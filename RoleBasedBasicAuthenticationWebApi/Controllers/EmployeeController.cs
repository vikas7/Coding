using RoleBasedBasicAuthenticationWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace RoleBasedBasicAuthenticationWebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        [BasicAuthentication]
        [MyAuthorize(Roles ="Admin")]
        [Route("api/AllMaleEmployees")]
        public HttpResponseMessage GetAllMaleEmployees()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var id = identity.Claims.FirstOrDefault(c => c.Type == "ID").Value;
            var email = identity.Claims.FirstOrDefault(c => c.Type == "Email").Value;
            var username = identity.Name;
            var empList = new EmployeeBL().GetEmployees().Where(e => e.Gender.ToLower() == "male").ToList();
            return Request.CreateResponse(HttpStatusCode.OK, empList);
        }
        
        [BasicAuthentication]
        [MyAuthorize(Roles ="SuperAdmin")]
        [Route("api/AllFemaleEmployees")]
        public HttpResponseMessage GetAllFemaleEmployees()
        {
            var emplist = new EmployeeBL().GetEmployees().Where(e => e.Gender.ToLower() == "female").ToList();
            return Request.CreateResponse(HttpStatusCode.OK, emplist);
        }

        [BasicAuthentication]
        [MyAuthorize(Roles ="Admin, SuperAdmin")]
        [Route("api/AllEmployees")]
        public HttpResponseMessage GetAllEmloyees()
        {
            var emplist = new EmployeeBL().GetEmployees().ToList();
            return Request.CreateResponse(HttpStatusCode.OK, emplist);
        }
    }
}
