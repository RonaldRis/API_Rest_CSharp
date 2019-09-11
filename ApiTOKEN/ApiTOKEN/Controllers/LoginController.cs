using ApiTOKEN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiTOKEN.Controllers
{
    [AllowAnonymous] //Es lo contrario de [Authorize], para que cualquiera pueda llegar aqui
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        private Model1 db = new Model1(); //Es mi conexion ADO.Net con la base de datos

        [HttpPost]
        [Route("logueo")]
        public HttpResponseMessage Logueo(users login)
        {
            if (login == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, "No se recibieron datos para el login");
            }
            var usuario = db.users.SingleOrDefault(p => p.username == login.username); //El usuario es unico!! Así que busco un unico dato
            if (usuario == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Asegurese de ingresar un usuario correcto");
            }
            var pass = usuario.pass; //la de la base de datos
            bool isPasswordAccepted = (login.pass == pass);
            if (isPasswordAccepted)
            {
                var tokenUser = Token.TokenGenerator.GenerateTokenJwt(login.username);
                return Request.CreateResponse(HttpStatusCode.OK, tokenUser);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Usuario o contraseña incorrecta");
        }
    }
}
