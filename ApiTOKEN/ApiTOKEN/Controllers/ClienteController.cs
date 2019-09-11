using ApiTOKEN.Models;
using ApiTOKEN.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiTOKEN.Controllers
{
    public class ClienteController : ApiController
    {
        IRepository<Cliente> r = new Rcliente();

        [Authorize]
        public HttpResponseMessage GetCLiente()
        {
            var items = r.GetAll();
            if (items==null || items.Count==0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NoContent, "No hay datos");
            }
            return Request.CreateResponse(HttpStatusCode.OK, items);
        }
    }
}
