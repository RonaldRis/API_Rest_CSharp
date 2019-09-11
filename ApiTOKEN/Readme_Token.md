Creating TOKENS!!

[Authorize]
When token is required! Can be applied to methods or to complete classes
 
 
# First and general setting

//Formato Json
	On Global.asax
	GlobalConfiguration.Configuration.Formatters.Clear();
            GlobalConfiguration.Configuration.Formatters.Add(new JsonMediaTypeFormatter());


<b>Nudgets needed!</b>
<ul>
	<li>Microsoft.IdentityModel.Tokens</li>
	<li>Microsoft.IdentityModel.json</li>
	<li>System.IdentityModel.Tokens.Jwt</li>
	<li>Microsoft.IdentityModel.Logging</li>
</ul>


<b>Create Token folder</b>

*Create classes: 

	<b>Class:</b>
		TokenGenerator

	Inside namespace add
	
		using Microsoft.IdentityModel.Tokens;
		using System;
		using System.Configuration;
		using System.Security.Claims;
		internal static class TokenGenerator
		{
			public static string GenerateTokenJwt(string username)
			{
				//Variables que guradaran la configuracion de la app para el token JWT
				var secretKey = ConfigurationManager.AppSettings["JWT_SECRET_KEY"];
				var audienceToken = ConfigurationManager.AppSettings["JWT_AUDIENCE_TOKEN"];
				var issuerToken = ConfigurationManager.AppSettings["JWT_ISSUER_TOKEN"];
				var expireTime = ConfigurationManager.AppSettings["JWT_EXPIRE_MINUTES"];

				var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secretKey));
				var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

				// Creando la identidad de las credenciales
				ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) });

				// Creando token del usuario
				var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
				var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
					audience: audienceToken,
					issuer: issuerToken,
					subject: claimsIdentity,
					notBefore: DateTime.UtcNow,
					expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime)),
					signingCredentials: signingCredentials);

				var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
				return jwtTokenString;
			}
		}
		
		
	<b>Class:</b>
		
		TokenValidationHandler
	Inside namespace add
	
	using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;
    internal class TokenValidationHandler : DelegatingHandler
    {
        private static bool TryRetrieveToken(HttpRequestMessage request, out string token)
        {
            token = null;
            IEnumerable<string> authzHeaders;
            if (!request.Headers.TryGetValues("Authorization", out authzHeaders) || authzHeaders.Count() > 1)
            {
                return false;
            }
            var bearerToken = authzHeaders.ElementAt(0);
            token = bearerToken.StartsWith("Bearer ") ? bearerToken.Substring(7) : bearerToken;
            return true;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpStatusCode statusCode;
            string token;

            // Determinar ya sea si el token existe o no existe
            if (!TryRetrieveToken(request, out token))
            {
                statusCode = HttpStatusCode.Unauthorized;
                return base.SendAsync(request, cancellationToken);
            }

            try
            {
                var secretKey = ConfigurationManager.AppSettings["JWT_SECRET_KEY"];
                var audienceToken = ConfigurationManager.AppSettings["JWT_AUDIENCE_TOKEN"];
                var issuerToken = ConfigurationManager.AppSettings["JWT_ISSUER_TOKEN"];
                var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secretKey));

                SecurityToken securityToken;
                var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
                TokenValidationParameters validationParameters = new TokenValidationParameters()
                {
                    ValidAudience = audienceToken,
                    ValidIssuer = issuerToken,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    LifetimeValidator = this.LifetimeValidator,
                    IssuerSigningKey = securityKey
                };

                //Extraer y asignar principal y usuario actual
                Thread.CurrentPrincipal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);
                HttpContext.Current.User = tokenHandler.ValidateToken(token, validationParameters, out securityToken);

                return base.SendAsync(request, cancellationToken);
            }
            catch (SecurityTokenValidationException)
            {
                statusCode = HttpStatusCode.Unauthorized;
            }
            catch (Exception)
            {
                statusCode = HttpStatusCode.InternalServerError;
            }

            return Task<HttpResponseMessage>.Factory.StartNew(() => new HttpResponseMessage(statusCode) { });
        }

        public bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            if (expires != null)
            {
                if (DateTime.UtcNow < expires) return true;
            }
            return false;
        }
    }

	
	
	
	
	
	
	
	<b>Apss_star/WebApiConfig</b>
	
		Exactly where the constructor begins:
		
		
			//Rutas del api web

            config.MapHttpAttributeRoutes();

            //Token
            config.MessageHandlers.Add(new Token.TokenValidationHandler());

 <b>Web.Config</b>
	Inside the tags appSettings
	
<appSettings>
    <add key="JWT_SECRET_KEY" value="clave-secreta-api"/>
    <add key="JWT_AUDIENCE_TOKEN" value="http://localhost:60890/"/>
    <add key="JWT_ISSUER_TOKEN" value="http://localhost:60890/"/>
    <add key="JWT_EXPIRE_MINUTES" value="60"/>
    
</appSettings>
	
	El value de JWT_AUDIENCE_TOKEN y JWT_ISSUER_TOKEN es la URL base del proyecto, en mi caso local es esa





# LoginController




using ApiTOKEN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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


