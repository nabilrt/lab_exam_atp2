using LabExamBussinessLogicLayer.DTOs;
using LabExamBussinessLogicLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LabExamAPI.Controllers
{
    public class AuthorizationController : ApiController
    {
        [Route("api/login")]
        [HttpPost]
        public HttpResponseMessage Login(LoginDTO login)
        {
            if (login == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Username password not supplied");
            }
            if (ModelState.IsValid)
            {
                var token = UserServices.Authenticate(login.Uname, login.Password);
                if (token != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, token);
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, "Username password invalid");
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }
    }
}
