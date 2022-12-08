using LabExamBussinessLogicLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace LabExamAPI.Auth
{
    public class IsLoggedAdmin : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var token = actionContext.Request.Headers.Authorization;
            //  var uID=DataAccessFactory
            if (token == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, "No token supplied");

            }
            else 
            {
                var dbtoken=UserServices.IsTokenValid(token.ToString());    
                if(dbtoken == null)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, "Supplied Token is invalid or expired");

                }

                else
                {
                    var user = UserServices.get(dbtoken.UserId);
                    if (user == null || user.Type!="Admin")
                    {

                        actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, "You cannot access this link");

                    }
                }
            }
            base.OnAuthorization(actionContext);
        }
    }
}