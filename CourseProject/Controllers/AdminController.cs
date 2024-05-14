using BLL.DTOs;
using BLL.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CourseProject.Controllers
{
    public class AdminController : ApiController
    {
        [HttpPost]
        [Route("api/admin/create")]
        public HttpResponseMessage CreateAdmin([FromBody] AdminDTO adminDto)
        {
            try
            {

                var data = AdminService.CreateAdmin(adminDto);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

        }
        [HttpGet]
        [Route("api/admin/Getadmin")]
        public HttpResponseMessage GetAdmin([FromBody] AdminDTO adminDto)
        {
            try
            {

                var data = AdminService.GetAdmin(adminDto);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

        }
        [HttpPost]
        [Route("api/admin/login")]
        public HttpResponseMessage Login([FromBody] AdminDTO adminDto)
        {
            try
            {
                var res = AdminAuthService.Authenticatee(adminDto.Email, adminDto.Password);

                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Admin not found" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/admin/logout")]
        public HttpResponseMessage Logout()
        {
            try
            {

                var token = HttpContext.Current.Request.Headers["Authorization"];

                if (token == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Token not provided in the header" });
                }

                var isLoggedOut = AdminAuthService.Logout(token);

                if (isLoggedOut)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Logout successful" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Token not found or unable to logout" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }






    }
}

