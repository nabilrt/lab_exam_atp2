using LabExamAPI.Auth;
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
  //  [IsLogged]
    public class UserController : ApiController
    {
        [Route("api/users")]
        [HttpGet]
        [IsLoggedAdmin]

        public HttpResponseMessage getAllUser()
        {
            var data = UserServices.getALL();

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/user/{id}")]
        [HttpGet]
        [IsLogged]

        public HttpResponseMessage getUser(int id)
        {
            var data = UserServices.get(id);

            return Request.CreateResponse(HttpStatusCode.OK, data); 
        }

        [Route("api/user/add")]
        [HttpPost]
        
        public HttpResponseMessage addUser(UserDTO user)
        {
            var data=UserServices.AddUser(user);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/user/update")]
        [HttpPost]

        public HttpResponseMessage updateUser(UserDTO user) {
        
            var data=UserServices.updateUser(user);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/user/delete/{id}")]
        [HttpGet]
        [IsLoggedAdmin]
        public HttpResponseMessage deleteUser(int id)
        {
            var data = UserServices.RemoveUser(id);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
